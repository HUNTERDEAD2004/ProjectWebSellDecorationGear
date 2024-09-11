using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    internal interface IKeyboardRespository
    {
        Task<List<KeyBoardDetailsDto>> GetAllKeyBoard(CancellationToken cancellationToken);
        Task<KeyBoardDetailsDto> GetKeyBoardById(ViewKeyBoardsRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateKeyBoard(CreateKeyBoardsRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateKeyBoard(UpdateKeyBoardsRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteKeyBoard(DeleteKeyBoardsRequest request, CancellationToken cancellationToken);
    }
}
