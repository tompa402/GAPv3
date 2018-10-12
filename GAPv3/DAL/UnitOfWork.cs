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