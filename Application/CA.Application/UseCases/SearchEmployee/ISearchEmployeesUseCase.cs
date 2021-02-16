using System;
using System.Threading.Tasks;

namespace CA.Application.UseCases.SearchEmployee
{
    public interface ISearchEmployeesUseCase
    {
        Task<SearchEmployeesOutput> Execute(SearchEmployeesInput request);
    }
}
