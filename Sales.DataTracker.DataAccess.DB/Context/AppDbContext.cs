using Microsoft.EntityFrameworkCore;
using Sales.DataTracker.DataCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataAccess.DB.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<PizzaType> PizzasTypes { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=Database\\app.db");

           // var dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "YourDbName.db");
            string dbPath = Path.Combine("..", "Sales.DataTracker.DataAccess.DB", "Database\\app.db");

            optionsBuilder.UseSqlite("Filename = " + dbPath);
            base.OnConfiguring(optionsBuilder);
        }

       
    }
}
