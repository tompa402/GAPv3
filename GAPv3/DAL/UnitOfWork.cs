using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GAPv3.Migrations;
using GAPv3.Models;

namespace GAPv3.DAL
{
    public class UnitOfWork : IDisposable
    {
        private GAPv3Context context = new GAPv3Context();
        private GenericRepository<Norm> normRepository;
        private GenericRepository<Report> reportRepository;
        private GenericRepository<NormItem> normItemRepository;
        private GenericRepository<ReportValue> reportValueRepository;
        private GenericRepository<Status> statusRepository;
        private GenericRepository<Organisation> organisationRepository;
        private GenericRepository<Control> controlRepository;
        private GenericRepository<Reason> reasonRepository;
        private GenericRepository<User> userRepository;

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

        public GenericRepository<ReportValue> ReportValueRepository
        {
            get
            {

                if (this.reportValueRepository == null)
                {
                    this.reportValueRepository = new GenericRepository<ReportValue>(context);
                }
                return reportValueRepository;
            }
        }

        public GenericRepository<Status> StatusRepository
        {
            get
            {

                if (this.statusRepository == null)
                {
                    this.statusRepository = new GenericRepository<Status>(context);
                }
                return statusRepository;
            }
        }

        public GenericRepository<Organisation> OrganisationRepository
        {
            get
            {

                if (this.organisationRepository == null)
                {
                    this.organisationRepository = new GenericRepository<Organisation>(context);
                }
                return organisationRepository;
            }
        }

        public GenericRepository<Reason> ReasonRepository
        {
            get
            {

                if (this.reasonRepository == null)
                {
                    this.reasonRepository = new GenericRepository<Reason>(context);
                }
                return reasonRepository;
            }
        }

        public GenericRepository<Control> ControlRepository
        {
            get
            {

                if (this.controlRepository == null)
                {
                    this.controlRepository = new GenericRepository<Control>(context);
                }
                return controlRepository;
            }
        }

        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
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