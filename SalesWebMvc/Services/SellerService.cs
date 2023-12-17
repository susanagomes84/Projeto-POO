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
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        //criar um metodo para retornar todos os vendedores
        public List<Seller> FindAll()
        {
            //retornar todos os vendedores ordenados por nome
            return _context.Seller.ToList();
        }
    }
}
