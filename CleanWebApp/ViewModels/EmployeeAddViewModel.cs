using System.Collections.Generic;

namespace CA.WebApp.ViewModels
{
    public class EmployeeAddViewModel
    {
        public EmployeeViewModel Item { get; set; } = new EmployeeViewModel();
        public List<dynamic> EmployeeTypeList { get; set; }
        public string ErrorMessage { get; set; }
    }
}
