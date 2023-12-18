using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
	public class SellerService
	{
		//como tem de ter uma dependencia ao nosso DBContext, temos de criar uma dependencia para o DBContext
		//readonly para que essa dependencia nao possa ser alterada
		private readonly SalesWebMvcContext _context;

		//criar dependencia para o DBContext
		public SellerService(SalesWebMvcContext context) //injecao de dependencia
		{
			_context = context; //injecao de dependencia
		}

		//criar um metodo para retornar todos os vendedores
		public List<Seller> FindAll() //retornar uma lista de vendedores
		{
			//retornar todos os vendedores ordenados por nome
			return _context.Seller.ToList();
		}

		//criar um metodo para inserir um novo vendedor na base de dados
		public void Insert(Seller obj) //receber um objeto do tipo seller
		{
			//adicionar o objeto ao DBSet
			_context.Add(obj);
			//guardar as alteracoes na base de dados
			_context.SaveChanges();
		}

		//criar um metodo para retornar um vendedor pelo id
		public Seller FindById(int id) //receber um id do tipo int
		{
			//retornar o vendedor que tem o id igual ao id recebido
			return _context.Seller.FirstOrDefault(obj => obj.Id == id);
		}

		//criar um metodo para remover um vendedor da base de dados
		public void Remove(int id) //receber um id do tipo int
		{
			//criar um objeto do tipo seller que vai receber o vendedor que tem o id igual ao id recebido   
			var obj = _context.Seller.Find(id);
			//remover o objeto do DBSet
			_context.Seller.Remove(obj);
			//guardar as alteracoes na base de dados
			_context.SaveChanges();
		}
	}
}
