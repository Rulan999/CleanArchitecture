using System.Threading.Tasks;
using CA.Domain.Employees;
using CA.Domain.Helpers;

namespace CA.Application.UseCases.EditEmployee
{
    public interface IEditEmployeeUseCase
    {
        Task<CommandResult<int>> Execute(Employee request);
    }
}
