using System;
using System.Linq;
using System.Threading.Tasks;
using CA.Domain.Helpers;

namespace CA.Application.UseCases.SearchEmployee
{
    public class SeedDataUseCase : ISeedDataUseCase
    {
        private IWriteRepository _writeRepository;
       
        public SeedDataUseCase(
            IWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<CommandResult<int>> Execute()
        {
            return await _writeRepository.DataSeed();
        }
    }
}
