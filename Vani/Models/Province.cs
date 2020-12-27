﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vani.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Store> Stores { get; set; }
    }
}
