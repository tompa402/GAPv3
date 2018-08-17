using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.ViewModels;
using Microsoft.Ajax.Utilities;

namespace GAPv3.Service
{
    public class ReportService
    {
        private UnitOfWork unitOfWork;

        public ReportService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<ReportValue> CreateInitialReportValuesList(List<NormItem> rv)
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
                        childCountItemsAll++;
                        switch (child.StatusId)
                        {
                            case 1:
                                parent.FullImplCount++;
                                break;
                            case 2:
                                parent.PartImplCount++;
                                break;
                            case 3:
                                parent.NoImplCount++;
                                break;
                        }
                    }
                }
                parent.FullImpl = GetPostotak(parent.FullImplCount, childCountItemsAll);
                parent.PartImpl = GetPostotak(parent.PartImplCount, childCountItemsAll);
                parent.NoImpl = GetPostotak(parent.NoImplCount, childCountItemsAll);
            }
            return rvStatList;
        }

        public int GetPostotak(int? counted, int all)
        {
            int result = counted == null ? 0 : (int)Math.Round((decimal)counted / all * 100);
            return result;
        }

        public int GetPopunjenost(List<ReportValue> rv)
        {
            decimal popunjenost = (decimal)rv.Count(x => x.StatusId != null) / rv.Count(x => x.NormItem.IsItem) * 100;
            int postotakPopunjenosti = (int)Math.Round(popunjenost);
            return postotakPopunjenosti;
        }
    }
}