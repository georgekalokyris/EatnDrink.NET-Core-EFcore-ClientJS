using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlCafeData : ICafeData
    {
        private readonly OdeToFoodDbContext db;
        public SqlCafeData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Cafe Add(Cafe newCafe)
        {
            db.Add(newCafe);
            return newCafe;
        }

        public int Commit()
        {
            return db.SaveChanges(); 
        }

        public Cafe Delete(int id)
        {
            var cafe = GetById(id);
            if (cafe != null)
            {
                db.Cafes.Remove(cafe);
            }

            return cafe;
        }

        public Cafe GetById(int id)
        {
            return db.Cafes.Find(id);
        }

        public IEnumerable<Cafe> GetCafesByName(string name)
        {
            var query = from r in db.Cafes
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Cafe Update(Cafe updatedCafe)
        {
            var entity = db.Cafes.Attach(updatedCafe);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedCafe;

        }
    }
}
