using System.Threading.Tasks;
using CA.Domain.Helpers;
using CA.Domain.Employees;

namespace CA.Application
{
    public interface IWriteRepository
    {
        Task<CommandResult<int>> InsertEmployee(Employee model);
        Task<CommandResult<int>> UpdateEmployee(Employee model);

        Task<CommandResult<int>> DataSeed();

    }
}
