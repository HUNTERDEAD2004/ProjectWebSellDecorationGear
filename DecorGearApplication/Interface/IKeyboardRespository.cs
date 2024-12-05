﻿using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IKeyboardRespository
    {
        Task<List<KeyBoardDetailsDto>> GetAllKeyBoard(ViewKeyBoardsRequest? request, CancellationToken cancellationToken);
        Task<KeyBoardDetailsDto> GetKeyBoardById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<KeyBoardDetailsDto>> CreateKeyBoard(CreateKeyBoardsRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<KeyBoardDetailsDto>> UpdateKeyBoard(int id, UpdateKeyBoardDetails request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteKeyBoard(int id, CancellationToken cancellationToken);
    }
}
