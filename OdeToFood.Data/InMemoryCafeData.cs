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
               new Cafe{Id = 1, Name = "Starbucks", Location = "Edinburgh", Type = CoffeeShopType.SitIn},

               new Cafe{Id = 2, Name = "Costa", Location = "Glasgow", Type = CoffeeShopType.Takeaway}
           };
        }

        public Cafe GetById(int id)
        {
            return Cafes.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Cafe> GetCafesByName(string name)
        {
            return from c in Cafes
                   where string.IsNullOrEmpty(name) || c.Name.StartsWith(name)
                   orderby c.Name
                   select c;
        }
        
        public Cafe Update(Cafe updatedCafe)
        {
            var cafe = Cafes.SingleOrDefault(x => x.Id == updatedCafe.Id);
            if (cafe != null)
            {
                cafe.Name = updatedCafe.Name;
                cafe.Location = updatedCafe.Location;
                cafe.Type = updatedCafe.Type;
            }
            return cafe;

        }

        public int Commit()
        {
            return 0;
        }

        public Cafe Add(Cafe newCafe)
        {
            Cafes.Add(newCafe);
            newCafe.Id = Cafes.Max(x => x.Id) + 1;
            return newCafe;
        }

        public Cafe Delete(int id)
        {
            Cafe cafe = Cafes.FirstOrDefault(x => x.Id == id);

            if(cafe != null)
            {
                Cafes.Remove(cafe);
            }

            return cafe;
        }
    }

}
