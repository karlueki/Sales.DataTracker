using Microsoft.EntityFrameworkCore;
using Sales.DataTracker.DataCore.Entities;
using Sales.DataTracker.DataCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataAccess.DB.Repositories
{
    public class AppDbRepository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext = null;
        private readonly DbSet<T> _dbSet = null;

        public AppDbRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public bool DeleteAll()
        {
            var success = false;
            try
            {
                _dbSet.RemoveRange(_dbSet);
                success = true;
            }
            catch (Exception)
            {
                throw;
            }

            return success;
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }



        public bool InsertRange(IEnumerable<T> ts)
        {
            var success = false;
            try
            {
                foreach (var t in ts)
                {
                    Insert(t);
                }
                success = true;
            }
            catch (Exception)
            {
                throw;
            }

            return success;
        }

        private T Insert(T t)
        {
            try
            {
                _dbSet.Add(t);
            }
            catch (Exception)
            {
                throw;
            }

            return t;
        }

    }
}
