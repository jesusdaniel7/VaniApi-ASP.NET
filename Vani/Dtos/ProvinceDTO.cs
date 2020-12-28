﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vani.Models;

namespace Vani.Dtos
{
    public class ProvinceDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Store> Stores { get; set; }
    }
}
