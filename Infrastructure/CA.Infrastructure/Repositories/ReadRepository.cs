using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Application;
using CA.Domain.Employees;
using CA.Domain.EmployeeTypes;
using CA.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA.Infrastructure
{
    public class ReadRepository: BaseRepository, IReadRepository
    {
        public ReadRepository(BaseDBContext dbContext)
            : base(dbContext)
        {
          
        }

        public async Task<IEnumerable<EmployeeType>> GetEmployeeTypes()
        {
            var employeeTypeList = await _appDbContext
             .EmployeeTypeEntities
             .Select(x => ConstructEmployeeType(x))
             .ToListAsync();

            return employeeTypeList;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByName(string name)
        {
            var employeeList = await _appDbContext
              .EmployeeEntities
                .Include(x=>x.EmployeeType)
              .Where(x => EF.Functions.Like(x.Name, $"%{name}%"))
              .Select(x=>ConstructEmployee(x))
              .ToListAsync();

            return employeeList;
        }

        public async Task<Employee> GetEmployee(int Id)
        {
            var employee =  await _appDbContext.EmployeeEntities
                .Where(x => x.Id == Id)
                .Select(x=> ConstructEmployee(x))
                .FirstOrDefaultAsync();

            return employee;
        }

        private static Employee ConstructEmployee(EmployeeEntity employeeEntity)
        {
            var employeeType = employeeEntity.EmployeeType != null ?
                                        ConstructEmployeeType(employeeEntity.EmployeeType)
                                        : new EmployeeType( employeeEntity.EmployeeType_Id, string.Empty);
            return new Employee(
                employeeEntity.Id,
                employeeEntity.Name,
                employeeEntity.BirthDate,
                employeeEntity.TIN,
                employeeType
            );
        }


        private static EmployeeType ConstructEmployeeType(EmployeeTypeEntity employeeTypeEntity)
        {
            return new EmployeeType(
                employeeTypeEntity.Id,
                employeeTypeEntity.Description
            );
        }
    }
}
