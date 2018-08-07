using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.Models;

namespace GAPv3.DAL
{
    public class UnitOfWork : IDisposable
    {
        private GAPv3Context context = new GAPv3Context();
        private GenericRepository<Norm> normRepository;
        private GenericRepository<Report> reportRepository;
        private GenericRepository<NormItem> normItemRepository;

        public GenericRepository<Norm> NormRepository
        {
            get
            {

                if (this.normRepository == null)
                {
                    this.normRepository = new GenericRepository<Norm>(context);
                }
                return normRepository;
            }
        }

        public GenericRepository<Report> ReportRepository
        {
            get
            {

                if (this.reportRepository == null)
                {
                    this.reportRepository = new GenericRepository<Report>(context);
                }
                return reportRepository;
            }
        }

        public GenericRepository<NormItem> NormItemRepository
        {
            get
            {

                if (this.normItemRepository == null)
                {
                    this.normItemRepository = new GenericRepository<NormItem>(context);
                }
                return normItemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}