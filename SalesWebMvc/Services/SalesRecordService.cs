using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc.Services
{
    public class SalesRecordService //classe responsavel por acessar os dados de vendas no DB
    {
        private readonly SalesWebMvcContext _context; //como tem de ter uma dependencia ao nosso DBContext, temos de criar uma dependencia para o DBContext

        public SalesRecordService(SalesWebMvcContext context) //criar dependencia para o DBContext
        {
            _context = context; //injecao de dependencia
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) //criar um metodo para retornar todos os vendedores da base de dados
        {
            var result = from obj in _context.SalesRecord select obj; //criar um objeto do tipo IQueriable
            if (minDate.HasValue) //se a data minima tiver valor
            {
                result = result.Where(x => x.Date >= minDate.Value); //filtrar as vendas por data minima
            }

            if (maxDate.HasValue) //se a data maxima tiver valor
            {
                result = result.Where(x => x.Date <= maxDate.Value); //filtrar as vendas por data maxima
            }
            
            return await result //retornar todas as vendas
                .Include(x => x.Seller) //incluir o vendedor
                .Include(x => x.Seller.Department) //incluir o departamento
                .OrderByDescending(x => x.Date) //ordenar por data
                .ToListAsync(); //retornar uma lista
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate) //criar um metodo para retornar todos os vendedores da base de dados
        {
            var result = from obj in _context.SalesRecord select obj; //criar um objeto do tipo IQueriable
            if (minDate.HasValue) //se a data minima tiver valor
            {
                result = result.Where(x => x.Date >= minDate.Value); //filtrar as vendas por data minima
            }
            if (maxDate.HasValue) //se a data maxima tiver valor
            {
                result = result.Where(x => x.Date <= maxDate.Value); //filtrar as vendas por data maxima
            }
            return await result //retornar todas as vendas fazendo join com todas as tabelas
                .Include(x => x.Seller) //  incluir o vendedor
                .Include(x => x.Seller.Department) //incluir o departamento
                .OrderByDescending(x => x.Date) //ordenar por data
                .GroupBy(x => x.Seller.Department) //agrupar por departamento
                .ToListAsync(); //retornar uma lista
        }


    }
}
