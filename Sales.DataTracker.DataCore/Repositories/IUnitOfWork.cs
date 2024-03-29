using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataCore.Repositories
{
    public interface IUnitOfWork
    {
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPizzaRepository PizzaRepository { get; }
        IPizzaTypeRepository PizzaTypeRepository { get; }

        void Save();
    }
}
