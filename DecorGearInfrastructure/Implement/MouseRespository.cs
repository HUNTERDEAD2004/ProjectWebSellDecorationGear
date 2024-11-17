using AutoMapper;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class MouseRespository : IMouseRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public MouseRespository(AppDbContext appDbContext,IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ResponseDto<MouseDetailsDto>> CreateMouse(CreateMouseRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            try
            {
                var createMouse = _mapper.Map<MouseDetailsDto>(request);

                _appDbContext.Add(createMouse);

                _appDbContext.SaveChanges();

                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi cập nhật cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteMouse(int id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.MouseDetails.FindAsync(id, cancellationToken);
            if (keyResult != null) 
            {
                _appDbContext.MouseDetails.Remove(keyResult);
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

        public async Task<List<MouseDetailsDto>> GetAllMouse(ViewMouseRequest? request, CancellationToken cancellationToken)
        {
            var query = from md in _appDbContext.MouseDetails
                        select new MouseDetailsDto
                        {
                            MouseDetailID = md.MouseDetailID,
                            ProductID = md.ProductID,
                            Color = md.Color,
                            DPI = md.DPI,
                            Connectivity = md.Connectivity,
                            Dimensions = md.Dimensions,
                            Material = md.Material,
                            EyeReading = md.EyeReading,
                            Button = md.Button,
                            LED = md.LED,
                            SS = md.SS,
                            ImageProduct = _appDbContext.ImageLists
                                    .Where(img => img.MouseDetailID == md.MouseDetailID)
                                    .Select(img => img.ImagePath)
                                    .ToList()
                        };

            // Áp dụng các điều kiện lọc
            if (request.MouseDetailID.HasValue)
            {
                query = query.Where(x => x.MouseDetailID == request.MouseDetailID);
            }
            if (request.ProductID.HasValue)
            {
                query = query.Where(x => x.ProductID == request.ProductID);
            }
            if (!string.IsNullOrEmpty(request.Color))
            {
                query = query.Where(x => x.Color == request.Color);
            }
            if (request.DPI.HasValue)
            {
                query = query.Where(x => x.DPI == request.DPI);
            }
            if (!string.IsNullOrEmpty(request.Connectivity))
            {
                query = query.Where(x => x.Connectivity == request.Connectivity);
            }
            if (!string.IsNullOrEmpty(request.Dimensions))
            {
                query = query.Where(x => x.Dimensions == request.Dimensions);
            }
            if (!string.IsNullOrEmpty(request.Material))
            {
                query = query.Where(x => x.Material == request.Material);
            }
            if (!string.IsNullOrEmpty(request.EyeReading))
            {
                query = query.Where(x => x.EyeReading == request.EyeReading);
            }
            if (request.Button.HasValue)
            {
                query = query.Where(x => x.Button == request.Button);
            }
            if (!string.IsNullOrEmpty(request.LED))
            {
                query = query.Where(x => x.LED == request.LED);
            }
            if (!string.IsNullOrEmpty(request.SS))
            {
                query = query.Where(x => x.SS == request.SS);
            }

            // Thực hiện truy vấn
            var result = await query.ToListAsync();
            return result;


            //var result = await _appDbContext.MouseDetails.ToListAsync(cancellationToken);

            //return _mapper.Map<List<MouseDetailsDto>>(result);
        }

        public async Task<MouseDetailsDto> GetMouseById(int id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.MouseDetails.FindAsync(id,cancellationToken);

            return _mapper.Map<MouseDetailsDto>(keyResult);
        }

        public async Task<ResponseDto<MouseDetailsDto>> UpdateMouse(int id,UpdateMouseRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            try
            {
                var mouse = await _appDbContext.MouseDetails.FindAsync(id);

                mouse.ProductID = request.ProductID;
                mouse.Color = request.Color;
                mouse.DPI = request.DPI;
                mouse.Connectivity = request.Connectivity;
                mouse.Dimensions = request.Dimensions;
                mouse.Material = request.Material;
                mouse.EyeReading = request.EyeReading;
                mouse.Button = request.Button;
                mouse.LED = request.LED;
                mouse.SS = request.SS;

                _appDbContext.Update(mouse);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Cập nhật thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi cập nhật cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<MouseDetailsDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }
    }
}
