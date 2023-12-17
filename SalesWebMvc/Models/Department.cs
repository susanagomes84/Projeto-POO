

using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); //  colecao de Sellers

        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        //para adicionar um vendedor
        public void AddSeller (Seller seller)
        {
            Sellers.Add(seller);
        }   

        //operacao para calcular o total de vendas de um departamento num determinado periodo
        public double TotalSales (DateTime initial, DateTime final)
        {
            //filtrar  lista para obter outra lista mas com os parametros que quero
            return Sellers.Sum(seller => seller.TotalSales(initial, final)); // sr é um apelido para SalesRecord
        }
    }
}