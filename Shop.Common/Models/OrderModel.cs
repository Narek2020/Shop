﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Common.Models
{
   public class OrderModel
    {
        
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
