using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class CafeCountViewComponent : ViewComponent
    {
        private readonly ICafeData cafeData;
        public CafeCountViewComponent(ICafeData cafeData)
        {
            this.cafeData = cafeData;
        }

        public IViewComponentResult Invoke()
        {
            var count = cafeData.GetCountCafes();
            return View(count);
        }
    }
}
