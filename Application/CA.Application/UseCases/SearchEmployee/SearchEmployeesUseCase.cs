using System.Linq;
using System.Threading.Tasks;

namespace CA.Application.UseCases.SearchEmployee
{
    public class SearchEmployeesUseCase : ISearchEmployeesUseCase
    {
        private IReadRepository _readRepository;
       
        public SearchEmployeesUseCase(
            IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<SearchEmployeesOutput> Execute(SearchEmployeesInput request)
        {
            var employees = await _readRepository.GetEmployeesByName(request.Name);
            var employeeTypes = await _readRepository.GetEmployeeTypes();
            return new SearchEmployeesOutput()
            {
                Employees = employees.ToList(),
                EmployeeTypes = employeeTypes.ToList()
            };
        }
    }
}
