using AutoMapper;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class KeyboardRespository : IKeyboardRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public KeyboardRespository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<ErrorMessage> CreateKeyBoard(CreateKeyBoardsRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            // Thêm Sản Phẩm Mới
            try
            {
                var createKeyBoard = _mapper.Map<KeyboardDetail>(request);

                await _appDbContext.KeyboardDetails.AddAsync(createKeyBoard, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteKeyBoard(int id, CancellationToken cancellationToken)
        {
            var deleteKeyBoard = await _appDbContext.KeyboardDetails.FindAsync(id, cancellationToken);
            if (deleteKeyBoard != null)
            {
                _appDbContext.KeyboardDetails.Remove(deleteKeyBoard);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<KeyBoardDetailsDto>> GetAllKeyBoard(CancellationToken cancellationToken)
        {
            var keyBoards = await _appDbContext.KeyboardDetails.ToListAsync(cancellationToken);

            return _mapper.Map<List<KeyBoardDetailsDto>>(keyBoards);
        }

        public async Task<KeyBoardDetailsDto> GetKeyBoardById(int id, CancellationToken cancellationToken)
        {
            var keyBoardIds = await _appDbContext.KeyboardDetails.FindAsync(id, cancellationToken);

            return _mapper.Map<KeyBoardDetailsDto>(keyBoardIds);
        }

        public async Task<ErrorMessage> UpdateKeyBoard(int id,UpdateKeyBoardDetails request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            // Cập Nhật Sản Phẩm 
            try
            {
                var keyBoards = await _appDbContext.KeyboardDetails.FindAsync(id);

                keyBoards.ProductID = request.ProductID;
                keyBoards.KeycapMaterial = request.KeycapMaterial;
                keyBoards.Case = request.Case;
                keyBoards.Color = request.Color;
                keyBoards.Layout = request.Layout;
                keyBoards.Led = request.Led;
                keyBoards.PCB = request.PCB;
                keyBoards.SS = request.SS;
                keyBoards.Stabilizes = request.Stabilizes;
                keyBoards.Switch = request.Switch;
                keyBoards.SwitchLife = request.SwitchLife;
                keyBoards.SwitchMaterial = request.SwitchMaterial;

                _appDbContext.KeyboardDetails.Update(keyBoards);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}
