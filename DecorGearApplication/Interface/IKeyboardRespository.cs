﻿using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IKeyboardRespository
    {
        Task<List<KeyBoardDetailsDto>> GetAllKeyBoard(CancellationToken cancellationToken);
        Task<KeyBoardDetailsDto> GetKeyBoardById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateKeyBoard(CreateKeyBoardsRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateKeyBoard(int id, UpdateKeyBoardDetails request, CancellationToken cancellationToken);
        Task<bool> DeleteKeyBoard(int id, CancellationToken cancellationToken);
    }
}