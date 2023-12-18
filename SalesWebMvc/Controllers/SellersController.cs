using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
	public class SellersController : Controller
	{
		//criar uma dependencia para o seller service
		private readonly SellerService _sellerService; //readonly para que essa dependencia nao possa ser alterada
		private readonly DepartmentService _departmentService; //readonly para que essa dependencia nao possa ser alterada

		//injecao de dependencia
		public SellersController(SellerService sellerService, DepartmentService departmentService) //criar dependencia para o seller service
		{
			_sellerService = sellerService; //injecao de dependencia
			_departmentService = departmentService; //injecao de dependencia
		}

		//chamar o metodo findall do seller service
		public IActionResult Index() //criar uma acao para o seller service
		{
			var list = _sellerService.FindAll(); //chamar o metodo findall do seller service
			return View(list); //retornar a lista
		}

		public IActionResult Create() //criar uma acao para o seller service
		{
			var departments = _departmentService.FindAll(); //chamar o metodo findall do department service
			var viewModel = new SellerFormViewModel { Departments = departments }; //instanciar um objeto do tipo SellerFormViewModel
			return View(viewModel); //retornar a lista
		}
		//criar acao create post
		[HttpPost]//para indicar que é uma acao post
		[ValidateAntiForgeryToken]//para evitar ataques CSRF
		public IActionResult Create(Seller seller)//para receber um objeto do tipo seller
		{

			_sellerService.Insert(seller);//chamar o metodo insert do seller service
			return RedirectToAction(nameof(Index));//redirecionar para a acao index

		}
		public IActionResult Delete(int? id)//para receber um id do tipo int
		{
			if (id == null)//se o id for nulo
			{
				return NotFound();//retornar um erro
			}
			var obj = _sellerService.FindById(id.Value);//chamar o metodo findbyid do seller service
			if (obj == null)//se o objeto for nulo
			{
				return NotFound();//retornar um erro
			}
			return View(obj);//retornar o objeto
		}

		[HttpPost]//para indicar que é uma acao post
		[ValidateAntiForgeryToken]//para evitar ataques CSRF
		public IActionResult Delete(int id)//para receber um id do tipo int
		{
			_sellerService.Remove(id);//chamar o metodo remove do seller service
			return RedirectToAction(nameof(Index));//redirecionar para a acao index
		}

		public IActionResult Details(int? id)//para receber um id do tipo int
		{
			if (id == null)//se o id for nulo
			{
				return NotFound();//retornar um erro
			}
			var obj = _sellerService.FindById(id.Value);//chamar o metodo findbyid do seller service
			if (obj == null)//se o objeto for nulo
			{
				return NotFound();//retornar um erro
			}
			return View(obj);//retornar o objeto
		}

		
	}
}
