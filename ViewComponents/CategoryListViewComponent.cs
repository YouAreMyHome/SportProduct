using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SportProductMVC.ViewComponents
{
    public class CategoryListViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string selectedCategory)
        {
            var categories = new List<string> { "Vợt", "Bóng", "Cầu", "Đệm", "Quần áo" };
            ViewBag.SelectedCategory = selectedCategory;
            return View(categories);
        }
    }
}
