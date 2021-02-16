using System.Collections.Generic;
using System.Threading.Tasks;
using CA.Domain.EmployeeTypes;

namespace CA.Application.UseCases.GetEmployeeTypes
{
    public interface IGetEmployeeTypesUseCase
    {
        Task<List<EmployeeType>> Execute();
    }
}
