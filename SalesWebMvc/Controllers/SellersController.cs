using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

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

		public IActionResult Create()
		{
			return View();
		}
		//criar acao create post
		[HttpPost]//para indicar que é uma acao post
		[ValidateAntiForgeryToken]//para evitar ataques CSRF
		public IActionResult Create(Seller seller)//para receber um objeto do tipo seller
		{
			_sellerService.Insert(seller);//chamar o metodo insert do seller service
			return RedirectToAction(nameof(Index));//redirecionar para a acao index

		}

		
	}
}
