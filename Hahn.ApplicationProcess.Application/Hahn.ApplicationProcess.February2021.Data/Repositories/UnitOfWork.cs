using Hahn.ApplicationProcess.February2021.Data.Context;
using Hahn.ApplicationProcess.February2021.Data.Interfaces;
using Hahn.ApplicationProcess.February2021.Data.IRepositories;
using System;
using System.Collections;
using System.Collections.Generic; 

namespace Hahn.ApplicationProcess.February2021.Data.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly HahnDataContext context;
        private bool disposed;
        private Hashtable repositories;

        public UnitOfWork(HahnDataContext context)
        {
            this.context = context;
        }

     

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this.context);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)repositories[type];
        }

        public void Save()
        {
         
                context.SaveChanges();
      
        }

        #region Dispose method
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IRepository<T> IUnitOfWork.Repository<T>()
        {
            if (repositories == null)
                repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), this.context);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)repositories[type];
        }
        #endregion
    }
}
