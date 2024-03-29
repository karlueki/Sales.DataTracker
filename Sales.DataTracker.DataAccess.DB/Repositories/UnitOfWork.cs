using Microsoft.EntityFrameworkCore;
using Sales.DataTracker.DataAccess.DB.Context;
using Sales.DataTracker.DataCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataAccess.DB.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DbContext context = null;
        private object dbLock = new object();

        private IOrderRepository _orderRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        private IPizzaTypeRepository _pizzaTypeRepository;
        private IPizzaRepository _pizzaRepository;

        public IOrderRepository OrderRepository
        {
            get
            {
                if (_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(context);
                }

                return _orderRepository;
            }
        }

        public IOrderDetailsRepository OrderDetailsRepository
        {
            get
            {
                if (_orderDetailsRepository == null)
                {
                    _orderDetailsRepository = new OrderDetailsRepository(context);
                }

                return _orderDetailsRepository;
            }
        }

        public IPizzaRepository PizzaRepository
        {
            get
            {
                if (_pizzaRepository == null)
                {
                    _pizzaRepository = new PizzaRepository(context);
                }

                return _pizzaRepository;
            }
        }

        public IPizzaTypeRepository PizzaTypeRepository
        {
            get
            {
                if (_pizzaTypeRepository == null)
                {
                    _pizzaTypeRepository = new PizzaTypeRepository(context);
                }

                return _pizzaTypeRepository;
            }
        }

        public UnitOfWork()
        {
            context = new AppDbContext();
        }

        public void Save()
        {
            try
            {
                lock (dbLock)
                {
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
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

        void IUnitOfWork.Save()
        {
            try
            {
                lock (dbLock)
                {
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
