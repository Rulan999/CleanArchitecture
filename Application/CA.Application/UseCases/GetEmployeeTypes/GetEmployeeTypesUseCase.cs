using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CA.Domain.EmployeeTypes;

namespace CA.Application.UseCases.GetEmployeeTypes
{
    public class GetEmployeeTypesUseCase : IGetEmployeeTypesUseCase
    {
        private IReadRepository _readRepository;
       
        public GetEmployeeTypesUseCase(
            IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<List<EmployeeType>> Execute()
        {
            var employeeTypes = await _readRepository.GetEmployeeTypes();
            return employeeTypes.ToList();
        }
    }
}
