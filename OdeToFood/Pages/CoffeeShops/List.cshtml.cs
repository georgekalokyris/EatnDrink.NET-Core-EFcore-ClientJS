using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.CoffeeShops
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Cafe> Cafes { get; set; }

        private readonly IConfiguration configuration;
        private readonly ICafeData cafeData;
        public ListModel(IConfiguration configuration, ICafeData cafeData)
        {
            this.configuration = configuration;
            this.cafeData = cafeData;
        }        
        
        public void OnGet()
        {

            //Message = "Hey";
            Message = configuration["Message"];
            Cafes = cafeData.GetAll();
        }
    }
}
