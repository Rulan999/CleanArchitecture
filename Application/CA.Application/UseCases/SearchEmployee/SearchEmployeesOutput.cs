using System.Collections.Generic;
using CA.Domain.Employees;
using CA.Domain.EmployeeTypes;

namespace CA.Application.UseCases.SearchEmployee
{
    public class SearchEmployeesOutput
    {
        public List<Employee> Employees { get; set; }
        public List<EmployeeType> EmployeeTypes { get; set; }
    }
}
