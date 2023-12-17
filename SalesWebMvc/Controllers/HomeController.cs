using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Somos uma equipa de vendedores especializados de diversas áreas tecnológicas.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Como chegar até nós.";

            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "A presente Política de Privacidade destina-se a ajudá-lo a compreender as informações que recolhemos, o motivo para o fazermos, e como pode atualizar, gerir, exportar e eliminar as suas informações.";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
