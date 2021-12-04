﻿using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryCafeData : ICafeData
    {
        List<Cafe> Cafes;
        public InMemoryCafeData()
        {
            Cafes = new List<Cafe>()
           {
               new Cafe{Id = 1, Name = "Starbucks", Location = "Edinburgh", Type = CoffeeShopType.SitIn},

               new Cafe{Id = 2, Name = "Costa", Location = "Glasgow", Type = CoffeeShopType.Takeaway}
           };
        }
      

        public IEnumerable<Cafe> GetCafesByName(string name)
        {
            return from c in Cafes
                   where string.IsNullOrEmpty(name) || c.Name.StartsWith(name)
                   orderby c.Name
                   select c;
        }

        public Cafe GetCafeById(int cafeid)
        {
            return from c in Cafes
                   where c.Id == cafeid
                   select c;
        }
    }

}
