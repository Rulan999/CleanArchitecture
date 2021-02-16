using System;
using System.Threading.Tasks;
using CA.Domain.Helpers;

namespace CA.Application.UseCases.SearchEmployee
{
    public interface ISeedDataUseCase
    {
        Task<CommandResult<int>> Execute();
    }
}
