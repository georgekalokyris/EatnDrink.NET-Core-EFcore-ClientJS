using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;
namespace OdeToFood.Pages.CoffeeShops
{
    public class DeleteModel : PageModel
    {
        private readonly ICafeData cafeData;

        public Cafe cafe { get; set; }
        public DeleteModel(ICafeData cafeData)
        {
            this.cafeData = cafeData;
        }
        public IActionResult OnGet(int cafeId)
        {
            cafe = cafeData.GetById(cafeId);
            if(cafe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int cafeId)
        {
            var cafe = cafeData.Delete(cafeId);
            cafeData.Commit();
            if (cafe == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{cafe.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}
