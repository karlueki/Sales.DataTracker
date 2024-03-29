using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataTracker.DataCore.Entities
{
    public class Order: BaseEntity
    {
        [Key]
        public int Order_Id { get; set; }
        public DateOnly Date { get; set; }  
        public TimeOnly Time { get; set; }
        List<OrderDetails> OrderDetails { get; set; }    
    }
}
