using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;

namespace OdeToFood.Pages.CoffeeShops
{
    public class DetailModel : PageModel
    {
        public Cafe Cafe { get; set; }
        public void OnGet(int cafeId)
        {
            Cafe = new Cafe();
        }
    }
}
