using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;
using System.Collections.Generic;
using SalesWebMvc.Services.Exceptions;
using System.Diagnostics;
using System;

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
			if (!ModelState.IsValid)//se o modelo nao for valido
			{
				var departments = _departmentService.FindAll();//chamar o metodo findall do department service
				var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };//instanciar um objeto do tipo SellerFormViewModel
				return View(viewModel);//retornar o objeto
			}

			_sellerService.Insert(seller);//chamar o metodo insert do seller service
			return RedirectToAction(nameof(Index));//redirecionar para a acao index

		}
		public IActionResult Delete(int? id)//para receber um id do tipo int
		{
			if (id == null)//se o id for nulo
			{
				return RedirectToAction(nameof(Error), new { message = "Id not provided."});//retornar um erro
			}
			var obj = _sellerService.FindById(id.Value);//chamar o metodo findbyid do seller service
			if (obj == null)//se o objeto for nulo
			{
				return RedirectToAction(nameof(Error), new { message = "Id not Found" });//retornar um err
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
				return RedirectToAction(nameof(Error), new { message = "Id not provided." });//retornar um err
			}
			var obj = _sellerService.FindById(id.Value);//chamar o metodo findbyid do seller service
			if (obj == null)//se o objeto for nulo
			{
				return RedirectToAction(nameof(Error), new { message = "Id not Found" });//retornar um err
			}
			return View(obj);//retornar o objeto
		}
		//criar acao edit
		public IActionResult Edit(int? id)//para receber um id do tipo int opcional
		{
			if (id == null)//se o id for nulo
			{
				return RedirectToAction(nameof(Error), new { message = "Id not provided." });//retornar um err
			}
			var obj = _sellerService.FindById(id.Value);//chamar o metodo findbyid do seller service
			if (obj == null)//se o objeto for nulo
			{
				return RedirectToAction(nameof(Error), new { message = "Id not Found" });//retornar um err
			}
			List<Department> departments = _departmentService.FindAll();//chamar o metodo findall do department service
			SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments }; //instanciar um objeto do tipo SellerFormViewModel
			return View(viewModel);//retornar o objeto
		}

		[HttpPost]//para indicar que é uma acao post
		[ValidateAntiForgeryToken]//para evitar ataques CSRF
		//criar acao edit post
		public IActionResult Edit(int id, Seller seller)//para receber um id do tipo int e um objeto do tipo seller
		{
			if (!ModelState.IsValid)//se o modelo nao for valido
			{
				var departments = _departmentService.FindAll();//chamar o metodo findall do department service
				var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };//instanciar um objeto do tipo SellerFormViewModel
				return View(viewModel);//retornar o objeto
			}

			if (id != seller.Id)//se o id for diferente do id do vendedor
			{
				return RedirectToAction(nameof(Error), new { message = "Id mismatch." });//retornar um err
			}
			try//tentar
			{
				_sellerService.Update(seller);//chamar o metodo update do seller service
				return RedirectToAction(nameof(Index));//redirecionar para a acao index
			}
			catch (ApplicationException e)//se houver uma excecao do tipo NotFoundException
			{
				return RedirectToAction(nameof(Error), new { message = e.Message});//retornar um erro
			}
			
		}
		//criar acao error
		public IActionResult Error(string message)//para receber uma mensagem do tipo string
		{
			var viewModel = new ErrorViewModel //instanciar um objeto do tipo ErrorViewModel
			{
				Message = message,//atribuir a mensagem
				RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier //atribuir o id interno do pedido
			};
			return View(viewModel);//retornar o objeto
		}
	}
}
