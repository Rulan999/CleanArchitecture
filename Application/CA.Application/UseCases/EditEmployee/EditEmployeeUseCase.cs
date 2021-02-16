using System;
using System.Threading.Tasks;
using CA.Application.UseCases.EditEmployee;
using CA.Domain.Employees;
using CA.Domain.Helpers;

namespace CA.Application.UseCases.AddEmployee
{
    public class EditEmployeeUseCase : IEditEmployeeUseCase
    {
        private IWriteRepository _writeRepository;
       
        public EditEmployeeUseCase(
            IWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CommandResult<int>> Execute(Employee request)
        {
            var result = await _writeRepository.UpdateEmployee(request);
            if (result.Status != CommandStatus.Success)
            {
                throw new Exception(result.ErrorMessage);
            }
            return result;
        }
    }
}
