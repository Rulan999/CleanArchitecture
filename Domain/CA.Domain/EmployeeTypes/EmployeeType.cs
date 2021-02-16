using System;
using System.Collections.Generic;
using CA.Domain.Employees;

namespace CA.Domain.EmployeeTypes
{
    public class EmployeeType
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Employee> Employees { get; set; }


        public EmployeeType(int id, string description, List<Employee> employees = null)
        {
            Id = id;
            Description = description;
            Employees = employees;
        }

    }
}
