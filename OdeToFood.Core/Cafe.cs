﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{
    public class Cafe 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        
        [Required, StringLength(255)]
        public string Location { get; set; }
        public CoffeeShopType Type { get; set; }

    }
}
