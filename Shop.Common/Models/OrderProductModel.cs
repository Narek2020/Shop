using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Models
{
   public class OrderProductModel
    { 
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> ProductPrice { get; set; }
        public Nullable<int> Count { get; set; }
    }
}
