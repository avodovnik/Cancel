using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo05.ViewComponents.ViewComponents
{
    public class PromotedProductsViewComponent : ViewComponent
    {
        private IProductService _productService;
        public PromotedProductsViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(decimal maxPrice)
        {
            var products = await _productService.GetPromotedProducts(maxPrice);
            return View(products);
        }

    }
}
