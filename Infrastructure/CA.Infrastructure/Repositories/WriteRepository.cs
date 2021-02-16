using System.Threading.Tasks;
using CA.Domain.Helpers;
using CA.Domain.Employees;
using CA.Application;
using CA.Infrastructure.Entities;
using AutoMapper;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CA.Domain.EmployeeTypes;

namespace CA.Infrastructure
{
    public class WriteRepository : BaseRepository, IWriteRepository
    {
        public WriteRepository(BaseDBContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<CommandResult<int>> InsertEmployee(Employee model)
        {
            var employeeEntity = new EmployeeEntity();
            var commandResult = new CommandResult<int>();

            try
            {
                ConstructEmployeeEntity(model, employeeEntity);
                _appDbContext.EmployeeEntities
                             .Add(employeeEntity);
                await _appDbContext.SaveChangesAsync();
                commandResult.Status = CommandStatus.Success;
            }
            catch (Exception ex)
            {
                commandResult.Status = CommandStatus.Error;
                commandResult.ErrorMessage = ex.Message;
            }
            commandResult.Result = employeeEntity.Id;
            return commandResult;
        }

        public async Task<CommandResult<int>> UpdateEmployee(Employee model)
        {
            var employeeEntity = _appDbContext.EmployeeEntities
                               .FirstOrDefault(o => o.Id == model.Id);

            var commandResult = new CommandResult<int>();
            commandResult.Result = employeeEntity.Id;

            try
            {
                ConstructEmployeeEntity(model, employeeEntity);
                await _appDbContext.SaveChangesAsync();
                commandResult.Status = CommandStatus.Success;
            }
            catch (Exception ex)
            {
                commandResult.Status = CommandStatus.Error;
                commandResult.ErrorMessage = ex.Message;
            }

            return commandResult;
        }

        public async Task<CommandResult<int>> DataSeed()
        {
            var employeeTypeCount = _appDbContext.EmployeeTypeEntities.Count();
            if (employeeTypeCount == 0)
            {
                _appDbContext.EmployeeTypeEntities.Add(new EmployeeTypeEntity()
                {
                    Id = 1,
                    Description = "Regular Employee"
                });

                _appDbContext.EmployeeTypeEntities.Add(new EmployeeTypeEntity()
                {
                    Id = 2,
                    Description = "Contractual Employee"
                });
            }
            var employeeCount = _appDbContext.EmployeeEntities.Count();
            if (employeeCount==0)
            {
                _appDbContext.EmployeeEntities.Add(new EmployeeEntity()
                {
                    Name ="Rulan",
                    BirthDate = new DateTime(2000,1,12),
                    EmployeeType_Id = 1,
                    TIN = "Tax-001"
                });
            }

            var commandResult = new CommandResult<int>();
            commandResult.Result = 0;

            try
            {
                await _appDbContext.SaveChangesAsync();
                commandResult.Status = CommandStatus.Success;
            }
            catch (Exception ex)
            {
                commandResult.Status = CommandStatus.Error;
                commandResult.ErrorMessage = ex.Message;
            }

            return commandResult;
        }

        private static void ConstructEmployeeEntity(Employee employee, EmployeeEntity employeeEntity)
        {
            employeeEntity.Id = employee.Id;
            employeeEntity.BirthDate = employee.BirthDate;
            employeeEntity.EmployeeType_Id = employee.EmployeeType.Id;
            employeeEntity.Name = employee.Name;
            employeeEntity.TIN = employee.TIN;
        }
    }
}
