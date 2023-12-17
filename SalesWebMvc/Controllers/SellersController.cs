using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        //criar uma dependencia para o seller service
        private readonly SellerService _sellerService;

        //injecao de dependencia
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        //chamar o metodo findall do seller service
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

    }
}
