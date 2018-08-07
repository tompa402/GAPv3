using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.DAL;
using GAPv3.Models;

namespace GAPv3.Service
{
    public class ReportService
    {
        private UnitOfWork unitOfWork;

        public ReportService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

    }
}