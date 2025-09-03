using Microsoft.AspNetCore.Mvc;
using WebApplication29_08.Models;

namespace WebApplication29_08.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        protected Product product = new Product();
        public IViewComponentResult Invoke()
        {
            var hotProducts = product.GetProductsList();
            return View(hotProducts);
        }
    }
}
