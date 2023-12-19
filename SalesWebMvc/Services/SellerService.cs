using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using System.Threading.Tasks;

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

		
		public async Task<List<Seller>> FindAllAsync() //criar um metodo para retornar todos os vendedores da base de dados
		{
			
			return await _context.Seller.ToListAsync();//retornar todos os vendedores da base de dados
		}

		//criar um metodo para inserir um novo vendedor na base de dados
		public async Task InsertAsync(Seller obj) //receber um objeto do tipo seller
		{
			//adicionar o objeto ao DBSet
			_context.Add(obj);
			//guardar as alteracoes na base de dados
			await _context.SaveChangesAsync();
		}

		
		public async Task<Seller> FindByIdAsync(int id) //criar um metodo para retornar um vendedor por id
		{
			
			return await _context.Seller.Include(obj=> obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);//retornar um vendedor por id
		}

		
		public async Task RemoveAsync(int id) //criar um metodo para remover um vendedor por id
		{
			 
			var obj = await _context.Seller.FindAsync(id);//encontrar o objeto por id
			
			_context.Seller.Remove(obj);//remover o objeto do DBSet
			
			await _context.SaveChangesAsync();//guardar as alteracoes na base de dados
		}

		public async Task UpdateAsync(Seller obj)//	receber um objeto do tipo seller
		{
			bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);//verificar se existe algum objeto com o id passado como argumento
			//se o id do objeto nao existir na base de dados
			if (!hasAny) //se nao existir
			{
				//lançar uma excecao personalizada
				throw new NotFoundException("Id not found");
			}
			try //tentar
			{
				//atualizar o objeto no DBSet
				_context.Update(obj);
				//guardar as alteracoes na base de dados
				await _context.SaveChangesAsync();
			}
			//se houver uma excecao do tipo DbConcurrencyException
			catch (DbUpdateConcurrencyException e) //excecao a ser lancada pelo framework
			{
				//lançar uma excecao personalizada
				throw new DbConcurrencyException(e.Message);
			}
		}
	}
}
