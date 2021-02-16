using System;
using System.Threading.Tasks;
using CA.Domain.Employees;
using CA.Domain.Helpers;

namespace CA.Application.UseCases.AddEmployee
{
    public class AddEmployeeUseCase : IAddEmployeeUseCase
    {
        private IWriteRepository _writeRepository;
       
        public AddEmployeeUseCase(
            IWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CommandResult<int>> Execute(Employee request)
        {
            var result = await _writeRepository.InsertEmployee(request);
            if (result.Status != CommandStatus.Success)
            {
                throw new Exception(result.ErrorMessage);
            }
            return result;
        }
    }
}
