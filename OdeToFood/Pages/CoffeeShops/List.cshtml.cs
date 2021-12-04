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
        
        [BindProperty(SupportsGet =true)] //This is telling ASP.NET Core fr when instantiating this class and it's getting ready to execute this method to look for something called SearchTerm on the OnGet  
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration configuration, ICafeData cafeData)
        {
            this.configuration = configuration;
            this.cafeData = cafeData;
        }
        
        public void OnGet()
        {
            //SearchTerm = searchTerm; Alternative way of searchTerm binding
            //HttpContext.Request.QueryString Alternative way of model binding
            Message = "Check";
            Message = configuration["Message"]; //The value of the Message will come out of the appsettings.json
            Cafes = cafeData.GetCafesByName(SearchTerm);
        }
    }
}
