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
                    NormItem = parent
                };
                reportViwModel.ReportValues.Add(temp);

                foreach (var child in parent.Children.OrderBy(x => x.Order).ToList())
                {
                    ReportValue tempChild = new ReportValue()
                    {
                        NormItem = child
                    };
                    temp.Children.Add(tempChild);

                    foreach (var grandChild in child.Children.OrderBy(x => x.Order).ToList())
                    {
                        ReportValue tempGrandChild = new ReportValue()
                        {
                            NormItem = grandChild
                        };
                        tempChild.Children.Add(tempGrandChild);
                    }
                }
            }

            return reportViwModel;
        }

    }
}