using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SalesWebMvc.Services
{
	public class DepartmentService//classe responsavel por acessar os dados de departamento no DB
	{
		private readonly SalesWebMvcContext _context;//como tem de ter uma dependencia ao nosso DBContext, temos de criar uma dependencia para o DBContext
		public DepartmentService(SalesWebMvcContext context)//criar dependencia para o DBContext
		{
			_context = context;//injecao de dependencia
		}
		public async Task<List<Department>> FindAllAsync()//criar um metodo para retornar todos os departamentos da base de dados
		{
			return await _context.Department.OrderBy(x => x.Name).ToListAsync();//retornar todos os departamentos da base de dados
		}
	}
}
