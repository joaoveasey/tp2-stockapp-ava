﻿using StockApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
