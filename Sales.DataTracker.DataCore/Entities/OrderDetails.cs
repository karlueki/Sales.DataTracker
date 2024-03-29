using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataCore.Entities
{
    public class OrderDetails: BaseEntity
    {
        [Key]
        public int Order_Details_Id { get; set; }
        public int Order_Id {  get; set; }
        public string PizzaId { get; set; } 
        public int Quantity { get; set; }

        [ForeignKey("Order_Id")]
        public Order Order { get; set; }
        [ForeignKey("PizzaId")]
        public Pizza Pizza { get; set; }
    }
}
