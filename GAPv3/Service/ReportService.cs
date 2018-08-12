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


        public int GetPopunjenost(List<ReportValue> rv)
        {
            decimal popunjenost = (decimal)rv.Count(x => x.StatusId != null) / rv.Count(x => x.NormItem.IsItem) * 100;
            int postotakPopunjenosti = (int)Math.Round(popunjenost);
            return postotakPopunjenosti;
        }
    }
}