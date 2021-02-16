using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Domain.Employees;
using CA.Domain.EmployeeTypes;

namespace CA.Application
{
    public interface IReadRepository
    {
        Task<IEnumerable<Employee>> GetEmployeesByName(string name);
        Task<Employee> GetEmployee(int Id);
        Task<IEnumerable<EmployeeType>> GetEmployeeTypes();
    }
}
