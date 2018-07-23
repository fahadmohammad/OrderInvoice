﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoOrder.Data;

namespace GoOrder.Entities
{
    public class Item : Entity
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public  Order Order { get; set; }
    }
}
