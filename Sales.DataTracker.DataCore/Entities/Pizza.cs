using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataCore.Entities
{
    public class Pizza: BaseEntity
    {
        [Key]
        public string Id { get; set; }
        public string Pizza_Type_Id { get; set; }
        public string Size { get; set; }

        public double Price {  get; set; }

        [ForeignKey("Pizza_Type_Id")]
        public PizzaType PizzaType { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }
    }
}
