using OdeToFood.Core;
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
               new Cafe{Id = 1, Name = "Starbucks", Location = "Edinburgh", Type = CoffeeShopType.Regular},
               new Cafe{Id = 2, Name = "Costa", Location = "Glasgow", Type = CoffeeShopType.Takeaway}
           };
        }
        public IEnumerable<Cafe> GetAll()
        {
            return from c in Cafes
                   orderby c.Name
                   select c; 
        }
    }

}
