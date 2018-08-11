using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.DAL;
using GAPv3.Models;
using GAPv3.ViewModels;

namespace GAPv3.Service
{
    public class ReportService
    {
        private UnitOfWork unitOfWork;

        public ReportService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ReportViewModel CreateReportViewModel(List<NormItem> rv)
        {
            ReportViewModel reportViwModel = new ReportViewModel();

            foreach (var parent in rv)
            {
                ReportValue temp = new ReportValue()
                {
                    NormItemId = parent.NormItemId,
                    NormItem = parent
                };
                reportViwModel.ReportValues.Add(temp);

                foreach (var child in parent.Children.OrderBy(x => x.Order).ToList())
                {
                    ReportValue tempChild = new ReportValue()
                    {
                        NormItemId = child.NormItemId,
                        NormItem = child
                    };
                    temp.Children.Add(tempChild);

                    foreach (var grandChild in child.Children.OrderBy(x => x.Order).ToList())
                    {
                        ReportValue tempGrandChild = new ReportValue()
                        {
                            NormItemId = grandChild.NormItemId,
                            NormItem = grandChild
                        };
                        tempChild.Children.Add(tempGrandChild);
                    }
                }
            }

            return reportViwModel;
        }

        public void SaveReportValues(ReportViewModel reportViwModel)
        {
            Report report = new Report()
            {
                Name = reportViwModel.Name,
                NormId = 1,
                OrganisationId = reportViwModel.OrganisationId
            };
            unitOfWork.ReportRepository.Insert(report);
            unitOfWork.Save();

            int reportId = report.ReportId;

            foreach (var parent in reportViwModel.ReportValues)
            {
                parent.ReportId = reportId;
                unitOfWork.ReportValueRepository.Insert(parent);
                foreach (var child in parent.Children)
                {
                    child.ReportId = reportId;
                    unitOfWork.ReportValueRepository.Insert(child);

                    foreach (var grandChild in child.Children)
                    {
                        grandChild.ReportId = reportId;
                        unitOfWork.ReportValueRepository.Insert(grandChild);
                    }
                }
                unitOfWork.Save();
            }
        }

        public int GetPopunjenost(List<ReportValue> rv)
        {
            decimal popunjenost = (decimal)rv.Count(x => x.StatusId != null) / rv.Count(x => x.NormItem.IsItem) * 100;
            int postotakPopunjenosti = (int)Math.Round(popunjenost);
            return postotakPopunjenosti;
        }
    }
}