using Hahn.ApplicationProcess.February2021.Data.Context;
using Hahn.ApplicationProcess.February2021.Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Hahn.ApplicationProcess.February2021.Data.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private HahnDataContext context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(DbContextOptions options)
           
        {

        }

        public GenericRepository(HahnDataContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this.dbSet.Add(instance);
            }
        }

        public virtual IQueryable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Update(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                this.dbSet.Attach(instance);
                context.Entry(instance).State = EntityState.Modified;
            }
        }

        public virtual void Delete(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                if (context.Entry(instance).State == EntityState.Detached)
                {
                    dbSet.Attach(instance);
                }
                dbSet.Remove(instance);
            }
        }
    }
}
