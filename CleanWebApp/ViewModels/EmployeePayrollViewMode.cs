using System.ComponentModel.DataAnnotations;
using CA.Domain.Employees;

namespace CA.WebApp.ViewModels
{
    public class EmployeePayrollViewModel
    {
        public int Id { get; set; }
        public Employee employee { get; set; }
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal Absent { get; set; } = 0;
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        public decimal WorkingDays { get; set; } = 0;

        public decimal SalaryAmount { get; set; } = 0;
    }
}
