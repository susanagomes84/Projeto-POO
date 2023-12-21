using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers //namespace do controlador
{
    public class SalesRecordsController : Controller //classe controlador
    {
        private readonly SalesRecordService _salesRecordService; //readonly para que essa dependencia nao possa ser alterada

        public SalesRecordsController(SalesRecordService salesRecordService) //injecao de dependencia
        {
            _salesRecordService = salesRecordService; //injecao de dependencia
        }

        public IActionResult Index() //criar uma acao para o seller service
        {
            return View();//retornar a lista
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) //se a data minima tiver valor
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1); //definir a data minima
            }
            if (!maxDate.HasValue) //se a data maxima tiver valor
            {
                maxDate = DateTime.Now; //  definir a data maxima
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd"); //definir a data minima
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd"); //  definir a data maxima
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate); //chamar o metodo findbydate do sales record service
            return View(result); //retornar a lista
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate) 
        {
            if (!minDate.HasValue)//se a data minima tiver valor
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);//definir a data minima
            }
            if (!maxDate.HasValue)//se a data maxima tiver valor
            {
                maxDate = DateTime.Now;//definir a data maxima
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");//definir a data minima
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");//definir a data maxima
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);//chamar o metodo findbydate do sales record service
            return View(result);//retornar a lista
        }
    }
}