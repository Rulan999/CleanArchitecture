using System.Threading.Tasks;
using CA.Domain.Employees;

namespace CA.Application.UseCases.GetEmployee
{
    public interface IGetEmployeeUseCase
    {
        Task<Employee> Execute(int id);
    }
}
