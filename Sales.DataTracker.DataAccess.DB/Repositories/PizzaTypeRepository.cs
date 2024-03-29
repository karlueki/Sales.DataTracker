using Microsoft.EntityFrameworkCore;
using Sales.DataTracker.DataCore.Entities;
using Sales.DataTracker.DataCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataAccess.DB.Repositories
{
    public class PizzaTypeRepository: AppDbRepository<PizzaType>, IPizzaTypeRepository
    {
        public PizzaTypeRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
