using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Data;
using OdeToFood.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OdeToFood.Pages.CoffeeShops
{
    public class EditModel : PageModel
    {
        private readonly ICafeData cafeData;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> cafeTypes { get; set; }
        
        [BindProperty]
        public Cafe Cafe { get; set; }
        public EditModel(ICafeData cafeData, IHtmlHelper htmlHelper)
        {
            this.cafeData = cafeData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? cafeId)
        {
            cafeTypes = htmlHelper.GetEnumSelectList<CoffeeShopType>();
            if (cafeId.HasValue)
            {
                Cafe = cafeData.GetById(cafeId.Value);
            }
            else
            {
                Cafe = new Cafe();
            }
            if (Cafe == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                cafeTypes = htmlHelper.GetEnumSelectList<CoffeeShopType>();
                return Page();
            
            }
            
            if(Cafe.Id > 0)
            {
                cafeData.Update(Cafe);
                TempData["Message"] = "Cafe updated";
            }
            else
            {
                cafeData.Add(Cafe);
                TempData["Message"] = "Cafe added";

            }

            cafeData.Commit();
            
            return RedirectToPage("./Detail/", new { cafeId = Cafe.Id }); 

        }


    }
}
