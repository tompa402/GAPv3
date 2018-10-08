using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.ViewModels;
using Highsoft.Web.Mvc.Charts;
using Microsoft.Ajax.Utilities;

namespace GAPv3.Service
{
    public class ReportService
    {
        private GAPv3Context _context;

        public ReportService(GAPv3Context context)
        {
            _context = context;
        }
        public int GetPopunjenost(List<ReportValue> rv)
        {
            decimal popunjenost = (decimal)rv.Count(x => x.StatusId != null) / rv.Count(x => x.NormItem.IsItem) * 100;
            int postotakPopunjenosti = (int)Math.Round(popunjenost);
            return postotakPopunjenosti;
        }

        public IEnumerable<ReportViewModel> GetReportsForNorm(int? normId)
        {
            var reportsViewModels = new List<ReportViewModel>();
            var reports = _context.Reports.Where(r => r.NormId == normId).Include(o => o.Organisation).Include(n => n.Norm).Include(rv => rv.ReportValues);
            foreach (var report in reports)
            {
                var reportViewModel = new ReportViewModel
                {
                    ReportId = report.ReportId,
                    Name = report.Name,
                    NormId = report.Norm.NormId,
                    NormName = report.Norm.Name,
                    OrgName = report.Organisation.Name,
                    Popunjenost = GetPopunjenost(report.ReportValues)
                };
                reportsViewModels.Add(reportViewModel);
            }
            return reportsViewModels;
        }

        /* public List<ReportValue> CreateInitialReportValuesList(List<NormItem> rv)
         {
             List<ReportValue> newList = new List<ReportValue>();
             foreach (var parent in rv)
             {
                 ReportValue temp = new ReportValue()
                 {
                     NormItemId = parent.NormItemId,
                     NormItem = parent
                 };

                 foreach (var child in parent.Children.OrderBy(x => x.Order).ToList())
                 {
                     ReportValue tempChild = new ReportValue()
                     {
                         NormItemId = child.NormItemId,
                         NormItem = child
                     };

                     foreach (var grandChild in child.Children.OrderBy(x => x.Order).ToList())
                     {
                         ReportValue tempGrandChild = new ReportValue()
                         {
                             NormItemId = grandChild.NormItemId,
                             NormItem = grandChild
                         };
                         tempChild.Children.Add(tempGrandChild);
                     }
                     temp.Children.Add(tempChild);
                 }
                 newList.Add(temp);
             }

             return newList;
         }

         public void UpdateReportValues(List<ReportValue> rv)
         {
             foreach (var parent in rv)
             {
                 foreach (var child in parent.Children)
                 {
                     unitOfWork.ReportValueRepository.Update(child);

                     foreach (var grandChild in child.Children)
                     {
                         unitOfWork.ReportValueRepository.Update(grandChild);
                     }
                 }
             }
         }

         public ReportStatisticViewModel GetStatisticForReport(Report report)
         {
             var reportViewModel = Mapper.Map<Report, ReportStatisticViewModel>(report);
             reportViewModel.Popunjenost = GetPopunjenost(report.ReportValues);
             reportViewModel.ReportValues = PrepareReportValuesForStatistic(report.ReportValues.Where(x => x.NormItem.ParentId == null).ToList());

             return reportViewModel;
         }

         public List<ReportValueStatisticViewModel> PrepareReportValuesForStatistic(List<ReportValue> rvList)
         {
             List<ReportValueStatisticViewModel> rvStatList = Mapper.Map<List<ReportValue>, List<ReportValueStatisticViewModel>>(rvList);

             foreach (var parent in rvStatList)
             {
                 var childCountItemsAll = 0;
                 parent.FullImplCount = 0;
                 parent.PartImplCount = 0;
                 parent.NoImplCount = 0;

                 foreach (var child in parent.Children)
                 {
                     if (child.Children.Any())
                     {
                         var grandChildCountAll = child.Children.Count;
                         child.FullImplCount = child.Children.Count(x => x.StatusId == 1);
                         child.PartImplCount = child.Children.Count(x => x.StatusId == 2);
                         child.NoImplCount = child.Children.Count(x => x.StatusId == 3);

                         child.FullImpl = GetPostotak(child.FullImplCount, grandChildCountAll);
                         child.PartImpl = GetPostotak(child.PartImplCount, grandChildCountAll);
                         child.NoImpl = GetPostotak(child.NoImplCount, grandChildCountAll);

                         childCountItemsAll = childCountItemsAll + grandChildCountAll;
                         parent.FullImplCount = parent.FullImplCount + child.FullImplCount;
                         parent.PartImplCount = parent.PartImplCount + child.PartImplCount;
                         parent.NoImplCount = parent.NoImplCount + child.NoImplCount;
                     }
                     else
                     {
                         child.FullImplCount = 0;
                         child.PartImplCount = 0;
                         child.NoImplCount = 0;
                         childCountItemsAll++;
                         switch (child.StatusId)
                         {
                             case 1:
                                 child.FullImplCount = 1;
                                 parent.FullImplCount++;
                                 break;
                             case 2:
                                 child.PartImplCount = 1;
                                 parent.PartImplCount++;
                                 break;
                             case 3:
                                 child.NoImplCount = 1;
                                 parent.NoImplCount++;
                                 break;
                         }
                     }
                 }
                 parent.FullImpl = GetPostotak(parent.FullImplCount, childCountItemsAll);
                 parent.PartImpl = GetPostotak(parent.PartImplCount, childCountItemsAll);
                 parent.NoImpl = GetPostotak(parent.NoImplCount, childCountItemsAll);

                 parent.Chart = CreateChart(parent.Children, parent.NormItem.Name);
             }
             return rvStatList;
         }

         public int GetPostotak(int? counted, int all)
         {
             int result = counted == null ? 0 : (int)Math.Round((decimal)counted / all * 100);
             return result;
         }

         

         public Highcharts CreateChart(List<ReportValueStatisticViewModel> childList, string parentName)
         {
             Highcharts chart = new Highcharts
             {
                 Title = new Title
                 {
                     Text = parentName
                 },
                 XAxis = new List<XAxis>
                 {
                     new XAxis
                     {
                         Categories =  childList.Select(x => x.NormItem.Name).ToList()
                     }
                 },
                 YAxis = new List<YAxis>
                 {
                     new YAxis
                     {
                         Min = 0,
                         Title = new YAxisTitle
                         {
                             Text = "Total (in percent)"
                         },
                         StackLabels = new YAxisStackLabels
                         {
                             Enabled = true,
                             Style = new YAxisStackLabelsStyle() { FontWeight = "bold" }
                         }
                     }
                 },
                 Tooltip = new Tooltip
                 {
                     PointFormat = "<span style=\"color:{series.color}\">{series.name}</span>: <b>{point.y}</b> ({point.percentage:.0f}%)<br/>",
                     Shared = true
                 },
                 PlotOptions = new PlotOptions
                 {
                     Column = new PlotOptionsColumn
                     {
                         Stacking = PlotOptionsColumnStacking.Percent
                     }
                 },
                 Series = new List<Series>
                 {
                     new ColumnSeries
                     {
                         Name = "Potpuno implementirano",
                         Data = GenerateColumnSeriesData(childList.Select(x => x.FullImplCount).ToList())
                     },
                     new ColumnSeries
                     {
                         Name = "Djelomice implementirano",
                         Data = GenerateColumnSeriesData(childList.Select(x => x.PartImplCount).ToList())
                     },
                     new ColumnSeries
                     {
                         Name = "Nije implementirano",
                         Data = GenerateColumnSeriesData(childList.Select(x => x.NoImplCount).ToList())
                     }
                 }
             };
             return chart;
         }

         public List<ColumnSeriesData> GenerateColumnSeriesData(List<int?> data)
         {
             List<ColumnSeriesData> columnSeriesData = new List<ColumnSeriesData>();
             data.ForEach(p => columnSeriesData.Add(new ColumnSeriesData { Y = p }));
             return columnSeriesData;
         }

         public Highcharts CreateChartTest()
         {
             Highcharts chart = new Highcharts
             {
                 Chart = new Chart
                 {
                     Height = 400,
                     Type = ChartType.Column
                 },
                 Series = new List<Series>
                 {
                     new ColumnSeries
                     {
                         Name = "Brands",
                         ColorByPoint = true,
                         Data = new List<ColumnSeriesData>
                         {
                             new ColumnSeriesData { Name = "Microsoft Internet Explorer", Y = 56.3, Drilldown = "Microsoft Internet Explorer" },
                             new ColumnSeriesData { Name = "Chrome", Y = 24.03, Drilldown = "Chrome" },
                             new ColumnSeriesData { Name = "Firefox", Y = 10.3, Drilldown = "Firefox" },
                             new ColumnSeriesData { Name = "Safari", Y = 4.77, Drilldown = "Safari" },
                             new ColumnSeriesData { Name = "Opera", Y = 0.91, Drilldown = "Opera" },
                             new ColumnSeriesData { Name = "Proprietary or Undetectable", Y = 0.2, Drilldown = null }
                         }
                     }
                 }
             };

             return chart;
         }*/
    }
}