using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class KeyboardRespository : IKeyboardRespository
    {
        public Task<ErrorMessage> CreateKeyBoard(CreateKeyBoardsRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteKeyBoard(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<KeyBoardDetailsDto>> GetAllKeyBoard(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<KeyBoardDetailsDto> GetKeyBoardById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateKeyBoard(KeyBoardDetailsDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
