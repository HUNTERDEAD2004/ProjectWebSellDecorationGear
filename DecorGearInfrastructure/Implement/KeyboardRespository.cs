using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.SubCategory;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
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
        public async Task<ResponseDto<KeyBoardDetailsDto>> CreateKeyBoard(CreateKeyBoardsRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            // Thêm Sản Phẩm Mới
            try
            {
                var createKeyBoard = _mapper.Map<KeyboardDetail>(request);

                await _appDbContext.KeyboardDetails.AddAsync(createKeyBoard, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Tạo thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi tạo cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteKeyBoard(int id, CancellationToken cancellationToken)
        {
            var deleteKeyBoard = await _appDbContext.KeyboardDetails.FindAsync(id, cancellationToken);
            if (deleteKeyBoard != null)
            {
                _appDbContext.KeyboardDetails.Remove(deleteKeyBoard);
                _appDbContext.SaveChanges();
                return new ResponseDto<bool>
                {
                    DataResponse = true,
                    Status = StatusCodes.Status200OK,
                    Message = "Xóa thành công."
                };
            }
            return new ResponseDto<bool>
            {
                DataResponse = false,
                Status = StatusCodes.Status400BadRequest,
                Message = "Sửa thất bại."
            };
        }

        public async Task<List<KeyBoardDetailsDto>> GetAllKeyBoard(ViewKeyBoardsRequest? request, CancellationToken cancellationToken)
        {
            var query = (from kd in _appDbContext.KeyboardDetails
                         join i in _appDbContext.ImageLists on kd.KeyboardDetailID equals i.KeyboardDetailID into images
                         select new KeyBoardDetailsDto
                         {
                             KeyboardDetailID = kd.KeyboardDetailID,
                             ProductID = kd.ProductID,
                             Color = kd.Color,
                             Layout = kd.Layout,
                             Case = kd.Case,
                             Switch = kd.Switch,
                             SwitchLife = kd.SwitchLife,
                             Led = kd.Led,
                             KeycapMaterial = kd.KeycapMaterial,
                             SwitchMaterial = kd.SwitchMaterial,
                             SS = kd.SS,
                             Stabilizes = kd.Stabilizes,
                             PCB = kd.PCB,
                             ImageProduct = images.Select(img => img.ImagePath).ToList() // Tập hợp hình ảnh
                         }).AsNoTracking().AsQueryable();

            // Áp dụng các điều kiện lọc
            if (request.KeyboardDetailID.HasValue)
            {
                query = query.Where(x => x.KeyboardDetailID == request.KeyboardDetailID);
            }
            if (request.ProductID.HasValue)
            {
                query = query.Where(x => x.ProductID == request.ProductID);
            }
            if (!string.IsNullOrEmpty(request.Color))
            {
                query = query.Where(x => x.Color == request.Color);
            }
            if (!string.IsNullOrEmpty(request.Layout))
            {
                query = query.Where(x => x.Layout == request.Layout);
            }
            if (!string.IsNullOrEmpty(request.Case))
            {
                query = query.Where(x => x.Case == request.Case);
            }
            if (!string.IsNullOrEmpty(request.Switch))
            {
                query = query.Where(x => x.Switch == request.Switch);
            }
            if (request.SwitchLife.HasValue)
            {
                query = query.Where(x => x.SwitchLife == request.SwitchLife);
            }
            if (!string.IsNullOrEmpty(request.Led))
            {
                query = query.Where(x => x.Led == request.Led);
            }
            if (!string.IsNullOrEmpty(request.KeycapMaterial))
            {
                query = query.Where(x => x.KeycapMaterial == request.KeycapMaterial);
            }
            if (!string.IsNullOrEmpty(request.SwitchMaterial))
            {
                query = query.Where(x => x.SwitchMaterial == request.SwitchMaterial);
            }
            if (!string.IsNullOrEmpty(request.SS))
            {
                query = query.Where(x => x.SS == request.SS);
            }
            if (!string.IsNullOrEmpty(request.Stabilizes))
            {
                query = query.Where(x => x.Stabilizes == request.Stabilizes);
            }
            if (!string.IsNullOrEmpty(request.PCB))
            {
                query = query.Where(x => x.PCB == request.PCB);
            }

            // Thực hiện truy vấn
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<KeyBoardDetailsDto> GetKeyBoardById(int id, CancellationToken cancellationToken)
        {
            var keyBoardIds = await _appDbContext.KeyboardDetails.FindAsync(id, cancellationToken);

            return _mapper.Map<KeyBoardDetailsDto>(keyBoardIds);
        }

        public async Task<ResponseDto<KeyBoardDetailsDto>> UpdateKeyBoard(int id,UpdateKeyBoardDetails request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
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

                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status200OK,
                    Message = "Cật nhật thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi cập nhật cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<KeyBoardDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }
    }
}
