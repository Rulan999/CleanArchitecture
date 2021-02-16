using System.Collections.Generic;

namespace CA.WebApp.ViewModels
{
    public class EmployeeUpdateViewModel
    {
        public EmployeeViewModel Item { get; set; }
        public List<dynamic> EmployeeTypeList { get; set; }
        public string ErrorMessage { get; set; }
    }
}
