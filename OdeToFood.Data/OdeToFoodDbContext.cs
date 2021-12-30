using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options)
        {
             


        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cafe> Cafes { get; set; }

        /* To create a neew migration the startup project will need to be specified like this :
         * dotnet ef migrations add DeletedAndCreatedwithCafes -s ..\OdeToFood\OdeToFood.csproj
         */
    }
}
