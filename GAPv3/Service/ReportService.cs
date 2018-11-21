using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.ViewModels;
using PuppeteerSharp;
using PuppeteerSharp.Media;

namespace GAPv3.Service
{
    public class ReportService
    {
        private GAPv3Context _context;

        public ReportService(GAPv3Context context)
        {
            _context = context;
        }

        public ReportCardViewModel GetReportsForCard()
        {
            var reportsViewModels = new List<ReportViewModel>();
            if ((HttpContext.Current.User as CustomPrincipal)?.Identity is CustomIdentity identity)
            {
                var orgId = identity.User.OrganisationId;
                var reports = _context.Reports
                    .Where(o => o.OrganisationId == orgId)
                    .Include(o => o.Organisation)
                    .Include(n => n.Norm)
                    .Include(rv => rv.ReportValues.Select(s => s.Status))
                    .Include(rv => rv.ReportValues.Select(x => x.NormItem)).ToList()
                    .ToList();
                foreach (var report in reports)
                {
                    var reportViewModel = new ReportViewModel
                    {
                        ReportId = report.ReportId,
                        Name = report.Name,
                        NormId = report.Norm.NormId,
                        NormName = report.Norm.Name,
                        IsActive = report.IsActive,
                        IsLocked = report.IsLocked,
                        Popunjenost = GetPopunjenost(report.ReportValues)
                    };
                    reportsViewModels.Add(reportViewModel);
                }
            }

            var model = new ReportCardViewModel()
            {
                Norms = _context.Norms.Where(n => n.IsActive),
                ReportViewModels = reportsViewModels
            };
            return model;
        }

        public IEnumerable<ReportViewModel> GetReportsForNorm(int? normId)
        {
            var reportsViewModels = new List<ReportViewModel>();
            List<Report> reports;
            if (normId == 0)
            {
                reports = _context.Reports
                    .Include(o => o.Organisation)
                    .Include(n => n.Norm)
                    .Include(rv => rv.ReportValues.Select(s => s.Status))
                    .Include(rv => rv.ReportValues.Select(x => x.NormItem)).ToList();
            }
            else
            {
                reports = _context.Reports
                    .Where(r => r.NormId == normId)
                    .Include(o => o.Organisation)
                    .Include(n => n.Norm)
                    .Include(rv => rv.ReportValues.Select(s => s.Status))
                    .Include(rv => rv.ReportValues.Select(x => x.NormItem)).ToList();
            }
            

            foreach (var report in reports)
            {
                var reportViewModel = new ReportViewModel
                {
                    ReportId = report.ReportId,
                    Name = report.Name,
                    NormId = report.Norm.NormId,
                    NormName = report.Norm.Name,
                    OrgName = report.Organisation.Name,
                    Popunjenost = GetPopunjenost(report.ReportValues),
                    IsActiveIcon = report.IsActive ? "fa fa-check fa-lg fa-green" : "fa fa-times fa-lg fa-red",
                    IsLockedIcon = report.IsLocked ? "fa fa-lock fa-lg fa-red" : "fa fa-unlock-alt fa-lg fa-green",
                };
                reportsViewModels.Add(reportViewModel);
            }
            return reportsViewModels;
        }

        public ReportFormViewModel CreateReportViewModel(int id)
        {
            var normItems = _context.NormItems
                .Where(x => x.NormId == id && x.ParentId == null)
                .OrderBy(x => x.Order)
                .ToList();

            var reportViewModel = new ReportFormViewModel
            {
                NormId = id,
                Organisations = _context.Organisations.ToList(),
                ReportValues = CreateInitialReportValuesList(normItems)
            };
            return reportViewModel;
        }

        public int GetPopunjenost(List<ReportValue> rv)
        {
            decimal popunjenost = (decimal)rv.Count(x => x.StatusId != null) / rv.Count(x => x.NormItem.IsItem) * 100;
            int postotakPopunjenosti = (int)Math.Round(popunjenost);
            return postotakPopunjenosti;
        }

        public List<ReportValueFormViewModel> CreateInitialReportValuesList(List<NormItem> rv)
        {
            var statuses = _context.Statuses.ToList();
            var reasons = _context.Reasons.ToList();
            var controls = _context.Controls.ToList();
            var newList = new List<ReportValueFormViewModel>();
            foreach (var parent in rv)
            {
                var temp = new ReportValueFormViewModel()
                {
                    NormItemId = parent.NormItemId,
                    NormItem = parent,
                    Statuses = statuses,
                    Reasons = reasons,
                    Controls = controls
                };

                foreach (var child in parent.Children.OrderBy(x => x.Order).ToList())
                {
                    var tempChild = new ReportValueFormViewModel()
                    {
                        NormItemId = child.NormItemId,
                        NormItem = child,
                        Statuses = statuses,
                        Reasons = reasons,
                        Controls = controls
                    };

                    foreach (var grandChild in child.Children.OrderBy(x => x.Order).ToList())
                    {
                        var tempGrandChild = new ReportValueFormViewModel()
                        {
                            NormItemId = grandChild.NormItemId,
                            NormItem = grandChild,
                            Statuses = statuses,
                            Reasons = reasons,
                            Controls = controls
                        };
                        tempChild.Children.Add(tempGrandChild);
                    }
                    temp.Children.Add(tempChild);
                }
                newList.Add(temp);
            }
            return newList;
        }

        public List<ReportValueFormViewModel> CreateEditReportValuesList(List<ReportValueFormViewModel> rv)
        {
            var statuses = _context.Statuses.ToList();
            var reasons = _context.Reasons.ToList();
            var controls = _context.Controls.ToList();

            foreach (var parent in rv)
            {
                parent.Statuses = statuses;
                parent.Reasons = reasons;
                parent.Controls = controls;

                foreach (var child in parent.Children.OrderBy(x => x.NormItem.Order).ToList())
                {
                    child.Statuses = statuses;
                    child.Reasons = reasons;
                    child.Controls = controls;

                    foreach (var grandChild in child.Children.OrderBy(x => x.NormItem.Order).ToList())
                    {
                        grandChild.Statuses = statuses;
                        grandChild.Reasons = reasons;
                        grandChild.Controls = controls;
                    }
                }
            }
            return rv;
        }

        public Report GetById(int id)
        {
            return _context.Reports
                .Include(x => x.ReportValues.Select(ni => ni.NormItem))
                .Include(x => x.ReportValues.Select(ni => ni.Status))
                .Include(x => x.ReportValues.Select(ni => ni.Control))
                .Include(x => x.ReportValues.Select(ni => ni.Reason))
                .SingleOrDefault(r => r.ReportId == id);
        }

        public ReportFormViewModel EditViewModel(Report report)
        {
            report.ReportValues = report.ReportValues.Where(x => x.NormItem.ParentId == null).ToList();
            var reportViewModel = Mapper.Map<Report, ReportFormViewModel>(report);
            reportViewModel.ReportValues = CreateEditReportValuesList(reportViewModel.ReportValues);
            reportViewModel.Organisations = _context.Organisations.ToList();
            return reportViewModel;
        }

        public ReportDetailsViewModel DetailsViewModel(Report report)
        {
            report.ReportValues = report.ReportValues.Where(x => x.NormItem.ParentId == null).ToList();
            var reportViewModel = Mapper.Map<Report, ReportDetailsViewModel>(report);

            var norm = _context.Norms.SingleOrDefault(n => n.NormId == report.NormId);

            reportViewModel.OrganisationName = _context.Organisations.SingleOrDefault(o => o.OrganisationId == report.OrganisationId)?.Name;
            reportViewModel.NormId = norm?.NormId;
            reportViewModel.NormName = norm?.Name;
            reportViewModel.AssignedUsers = _context.Users.Where(u => u.OrganisationId == report.OrganisationId).ToList();

            return reportViewModel;
        }

        public void InsertOrUpdate(Report report)
        {
            if (report.ReportId != 0)
            {
                report.Modified = DateTime.Now;

                _context.Entry(report).State = EntityState.Modified;

                foreach (var parent in report.ReportValues)
                {
                    foreach (var child in parent.Children)
                    {
                        if (!child.Children.Any())
                            _context.Entry(child).State = EntityState.Modified;

                        foreach (var item in child.Children)
                        {
                            _context.Entry(item).State = EntityState.Modified;
                        }
                    }
                }
            }
            else
            {
                _context.Entry(report).State = EntityState.Added;
            }
            _context.SaveChanges();
        }

        public int GetSukladnostSNormom(List<ReportValue> rv)
        {
            decimal popunjenost = (decimal)rv.Count(x => x.StatusId == 1 && (x.ControlId == 1 || x.ControlId == null)) / rv.Count(x => x.NormItem.IsItem && (x.ControlId == 1 || x.ControlId == null)) * 100;
            int postotakPopunjenosti = (int)Math.Round(popunjenost);
            return postotakPopunjenosti;
        }

        public ReportStatisticViewModel GetStatisticForReport(Report report)
        {
            var reportViewModel = Mapper.Map<Report, ReportStatisticViewModel>(report);
            reportViewModel.Popunjenost = GetSukladnostSNormom(report.ReportValues);

            var norm = _context.Norms.SingleOrDefault(n => n.NormId == report.NormId);

            reportViewModel.OrganisationName = _context.Organisations.SingleOrDefault(o => o.OrganisationId == report.OrganisationId)?.Name;
            reportViewModel.NormId = norm?.NormId;
            reportViewModel.NormName = norm?.Name;
            reportViewModel.AssignedUsers =
                _context.Users.Where(u => u.OrganisationId == report.OrganisationId).ToList();

            reportViewModel.ReportValues = PrepareReportValuesForStatistic(reportViewModel.ReportValues.Where(x => x.NormItem.ParentId == null).ToList());

            reportViewModel.ChartViewModels = reportViewModel.ReportValues.Select(c => c.Chart).ToList();

            return reportViewModel;
        }

        public List<ReportValueStatisticViewModel> PrepareReportValuesForStatistic(List<ReportValueStatisticViewModel> rvList)
        {
            foreach (var parent in rvList)
            {
                var childCountItemsAll = 0;
                parent.FullImplCount = 0;
                parent.PartImplCount = 0;
                parent.NoImplCount = 0;

                foreach (var child in parent.Children)
                {
                    if (child.Children.Any())
                    {
                        var grandChildCountAll = child.Children.Count(x => x.ControlId == 1 || x.ControlId == null);
                        child.FullImplCount = child.Children.Count(x => x.StatusId == 1 && (x.ControlId == 1 || x.ControlId == null));
                        child.PartImplCount = child.Children.Count(x => x.StatusId == 2 && (x.ControlId == 1 || x.ControlId == null));
                        child.NoImplCount = child.Children.Count(x => x.StatusId == 3 && (x.ControlId == 1 || x.ControlId == null));

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
                            case 1 when (child.ControlId == 1 || child.ControlId == null):
                                child.FullImplCount = 1;
                                parent.FullImplCount++;
                                break;
                            case 2 when (child.ControlId == 1 || child.ControlId == null):
                                child.PartImplCount = 1;
                                parent.PartImplCount++;
                                break;
                            case 3 when (child.ControlId == 1 || child.ControlId == null):
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
            return rvList;
        }

        public int GetPostotak(int? counted, int all)
        {
            int result = counted == null ? 0 : (int)Math.Round((decimal)counted / all * 100);
            return result;
        }

        public ChartViewModel CreateChart(List<ReportValueStatisticViewModel> childList, string parentName)
        {
            ChartViewModel chart = new ChartViewModel
            {
                TitleParentName = parentName,
                CategoriesNormItemName = childList.Select(x => x.NormItem.Name).ToList(),
                ColumnSeriesImplName = "Potpuno implementirano",
                ColumnSeriesImplData = childList.Select(x => x.FullImplCount).ToList(),
                ColumnSeriesPartImplName = "Djelomice implementirano",
                ColumnSeriesPartImplData = childList.Select(x => x.PartImplCount).ToList(),
                ColumnSeriesNoImplName = "Nije implementirano",
                ColumnSeriesNoImplData = childList.Select(x => x.NoImplCount).ToList()


            };
             return chart;
         }

        public void DeactivateSingleReport(int id)
        {
            var report = GetById(id);
            if (report != null)
            {
                report.IsActive = !report.IsActive;
                report.Modified = DateTime.Now;
            }

            _context.SaveChanges();
        }

        public void DeactivateAllReports()
        {
            var reports = _context.Reports.Where(i => i.IsActive);
            foreach (var report in reports)
            {
                report.IsActive = !report.IsActive;
                report.Modified = DateTime.Now;
            }

            _context.SaveChanges();
        }

        public void LockSingleReport(int id)
        {
            var report = GetById(id);
            if (report != null)
            {
                report.IsLocked = !report.IsLocked;
                report.Modified = DateTime.Now;
            }
            _context.SaveChanges();
        }

        public void LockAllReports()
        {
            var reports = _context.Reports.Where(i => i.IsActive);
            foreach (var report in reports)
            {
                report.IsLocked = !report.IsLocked;
                report.Modified = DateTime.Now;
            }

            _context.SaveChanges();
        }

        public async Task<byte[]> GetPdfForReport(string url)
        {
            var options = new LaunchOptions
            {
                Headless = true,
                ExecutablePath = HttpContext.Current.Server.MapPath("~/App_Data/.local-chromium/Win64-594312/chrome-win/chrome.exe"),
                Args = new []{"--no-sandbox", "--disable-setuid-sandbox"}
            };
            
            //Console.WriteLine("Downloading chromium");
            //await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);

            //Console.WriteLine("Navigating desired page");
            using (var browser = await Puppeteer.LaunchAsync(options))
            using (var page = await browser.NewPageAsync())
            {
                await page.GoToAsync(url);

                //Console.WriteLine("Generating PDF"); Commented line is to save pdf to server
                //await page.PdfAsync(Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/pdfReporting"), "google.pdf"));
                return await page.PdfDataAsync(new PdfOptions(){});

                // Console.WriteLine("Export completed");
            }
            //comments below are steps to get pdf from server
            //string filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/pdfReporting"), "google.pdf");
            //byte[] pdfByte = GetBytesFromFile(filepath);
            //return pdfByte;
            
        }

        public byte[] GetBytesFromFile(string fullFilePath)
        {
            // this method is limited to 2^32 byte files (4.2 GB)
            FileStream fs = null;
            try
            {
                fs = System.IO.File.OpenRead(fullFilePath);
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                return bytes;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }
            }
        }

        /*public List<ColumnSeriesData> GenerateColumnSeriesData(List<int?> data)
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