using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.CoffeeShops
{
    public class DetailModel : PageModel
    {
        public Cafe Cafe { get; set; }

        [TempData]
        public string Message { get; set; }

        public readonly ICafeData cafeData;
        public DetailModel(ICafeData cafeData)
        {
            this.cafeData = cafeData;
        }
        public IActionResult OnGet(int cafeId)
        {
            
            Cafe = cafeData.GetById(cafeId);
            if(Cafe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
