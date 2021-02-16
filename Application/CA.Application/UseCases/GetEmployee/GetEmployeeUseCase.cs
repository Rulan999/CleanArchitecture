using System.Threading.Tasks;
using CA.Domain.Employees;

namespace CA.Application.UseCases.GetEmployee
{
    public class GetEmployeeUseCase : IGetEmployeeUseCase
    {
        private IReadRepository _readRepository;
       
        public GetEmployeeUseCase(
            IReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<Employee> Execute(int id)
        {
            var employee = await _readRepository.GetEmployee(id);
            return employee;
        }
    }
}
