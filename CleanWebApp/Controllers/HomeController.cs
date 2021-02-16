using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanWebApp.Models;
using CA.Application.UseCases.SearchEmployee;

namespace CleanWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchEmployeesUseCase _searchEmployeesUseCase;
        private readonly ISeedDataUseCase _seedDataUseCase;
        public HomeController(ILogger<HomeController> logger,
                              ISeedDataUseCase seedDataUseCase,
                              ISearchEmployeesUseCase searchEmployeesUseCase)
        {
            _logger = logger;
            _searchEmployeesUseCase = searchEmployeesUseCase;
            _seedDataUseCase = seedDataUseCase;
        }

        public IActionResult Index()
        {
            _seedDataUseCase.Execute();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<SearchEmployeesOutput> SearchEmployees(string Name)
        {
            var employees = await _searchEmployeesUseCase.Execute(
                new SearchEmployeesInput() { Name = Name});
            
            return employees;
        }
    }
}
