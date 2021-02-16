using System.Threading.Tasks;
using CA.Domain.Employees;
using CA.Domain.Helpers;

namespace CA.Application.UseCases.AddEmployee
{
    public interface IAddEmployeeUseCase
    {
        Task<CommandResult<int>> Execute(Employee request);
    }
}
