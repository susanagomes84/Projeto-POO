using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;


namespace SalesWebMvc.Services
{
	public class DepartmentService//classe responsavel por acessar os dados de departamento no DB
	{
		private readonly SalesWebMvcContext _context;//como tem de ter uma dependencia ao nosso DBContext, temos de criar uma dependencia para o DBContext
		public DepartmentService(SalesWebMvcContext context)//criar dependencia para o DBContext
		{
			_context = context;
		}
		public List<Department> FindAll()//retornar todos os departamentos ordenados por nome
		{
			return _context.Department.OrderBy(x => x.Name).ToList();//retornar todos os departamentos ordenados por nome
		}
	}
}
