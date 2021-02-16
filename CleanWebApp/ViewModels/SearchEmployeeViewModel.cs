using System;
using CA.Application.UseCases.SearchEmployee;

namespace CA.WebApp.ViewModels
{
    public class SearchEmployeeViewModel
    {
        public SearchInputViewModel input { get; set; }
        public SearchEmployeesOutput output { get; set; }
    }

    public class SearchInputViewModel
    {
        public string Name { get; set; }
    }
}
