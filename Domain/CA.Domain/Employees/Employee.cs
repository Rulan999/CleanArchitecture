using System;
using CA.Domain.Constants;
using CA.Domain.EmployeeTypes;

namespace CA.Domain.Employees
{
    public class Employee 
    {
        public int Id { get; private set; }
        public String Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string TIN { get; private set; }
        public EmployeeType EmployeeType { get; private set;  }

        public Employee(int id, string name, DateTime birthDate, string tin, EmployeeType employeeType)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
            TIN = tin;
            EmployeeType = employeeType;
        }

        public static Employee Create(
             string name,
             DateTime birthdate,
             string tin,
             int employeeTypeId)
        {
            return new Employee(
                id: 0,
                name,
                birthdate,
                tin,
                new EmployeeType(employeeTypeId, string.Empty)
            );
        }

        public static Employee Update(
            int id,
             string name,
             DateTime birthdate,
             string tin,
             int employeeTypeId)
        {
            return new Employee(
               id: id,
               name,
               birthdate,
               tin,
               new EmployeeType(employeeTypeId, string.Empty)
           );
        }

        public Decimal CalculatePayrol(decimal absents, decimal workingDays)
        {
            if (EmployeeType.Id == 1)
            {
                return GetRate() - (GetRate()/22 * (decimal) absents) - (GetRate() * GetTax()/100) ;
            }
            else if (EmployeeType.Id == 2)
            {
                return GetRate() * workingDays;
            }
            else
            {
                return 0;
            }
        }

        public Decimal GetRate()
        {
            if(EmployeeType.Id ==1)
            {
                return SalaryRate.Regular.Rate;
            }
            else if (EmployeeType.Id == 2)
            {
                return SalaryRate.Contract.Rate;
            }
            else
            {
                return 0;
            }
        }

        public Decimal GetTax()
        {
            if (EmployeeType.Id == 1)
            {
                return SalaryRate.Regular.Tax;
            }
            else if (EmployeeType.Id == 2)
            {
                return SalaryRate.Contract.Tax;
            }
            else
            {
                return 0;
            }
        }
    }
}
