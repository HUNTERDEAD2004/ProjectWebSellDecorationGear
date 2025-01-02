 using AutoMapper;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DecorGearInfrastructure.Implement
{
    public class ProductRespository : IProductRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ProductRespository(AppDbContext context, IMapper mapper)
        {
            _appDbContext = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<ProductDto>> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return new ResponseDto<ProductDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            // Thêm Sản Phẩm Mới
            try
            {

                var createProduct = _mapper.Map<Product>(request);

                await _appDbContext.Products.AddAsync(createProduct, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<ProductDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tạo thành công."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<ProductDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi tạo cơ sở dữ liệu."
                };
            }
            catch (ArgumentException)
            {
                return new ResponseDto<ProductDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Tham số không hợp lệ."
                };
            }
            catch (Exception ex)
            {
                return new ResponseDto<ProductDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Lỗi không xác định: " + ex.Message + "."
                };
            }
        }

        public async Task<ResponseDto<bool>> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var deleteProducts = await _appDbContext.Products.FindAsync(id, cancellationToken);
            if (deleteProducts != null)
            {
                _appDbContext.Products.Remove(deleteProducts);
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

        //public async Task<List<ProductDto>> GetAllProduct(ViewProductRequest? request, CancellationToken cancellationToken)
        //{
        //    //var query = _appDbContext.Products.AsQueryable();
        //    //    .AsQueryable();

        //    //// Lọc sản phẩm 

        //    //if (!string.IsNullOrEmpty(request.ProductName))
        //    //{
        //    //    query = query.Where(x => x.ProductName == request.ProductName);
        //    //}
        //    //if (!string.IsNullOrEmpty(request.ProductCode))
        //    //{
        //    //    query = query.Where(x => x.ProductCode == request.ProductCode);
        //    //}

        //    //var resultProduct = await query.ToListAsync();
        //    //return resultProduct;
        //}

        //public async Task<ProductDto> GetKeyProductById(int id, CancellationToken cancellationToken)
        //{
        //    var productIds = await _appDbContext.Products.FindAsync(id, cancellationToken);

        //    return _mapper.Map<ProductDto>(productIds);
        //}

        //public async Task<ResponseDto<ProductDto>> UpdateProduct(int id,UpdateProductRequest request, CancellationToken cancellationToken)
        //{
        //    // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
        //    if (request == null)
        //    {
        //        return new ResponseDto<ProductDto>
        //        {
        //            DataResponse = null,
        //            Status = StatusCodes.Status400BadRequest,
        //            Message = "Chưa có request."
        //        };
        //    }

        //    // Cập Nhật Sản Phẩm 
        //    try
        //    {
        //        var product = await _appDbContext.Products.FindAsync(id,cancellationToken);

        //        product.ProductName = request.ProductName;
        //        product.Price = request.Price;
        //        product.View = request.View;
        //        product.Quantity = request.Quantity;
        //        product.Weight = request.Weight;
        //        product.Description = request.Description;
        //        product.Size = request.Size;
        //        product.BatteryCapacity = request.BatteryCapacity;
        //        product.SaleID = request.SaleID;
        //        product.BrandID = request.BrandID;
        //        product.SubCategoryID = request.SubCategoryID;
        //        product.AvatarProduct = request.AvatarProduct;

        //        _appDbContext.Products.Update(product);

        //        await _appDbContext.SaveChangesAsync(cancellationToken);

        //        return new ResponseDto<ProductDto>
        //        {
        //            DataResponse = null,
        //            Status = StatusCodes.Status400BadRequest,
        //            Message = "Chưa có request."
        //        };
        //    }
        //    catch (DbUpdateException)
        //    {
        //        return new ResponseDto<ProductDto>
        //        {
        //            DataResponse = null,
        //            Status = StatusCodes.Status500InternalServerError,
        //            Message = "Lỗi khi cập nhật cơ sở dữ liệu."
        //        };
        //    }
        //    catch (ArgumentException)
        //    {
        //        return new ResponseDto<ProductDto>
        //        {
        //            DataResponse = null,
        //            Status = StatusCodes.Status400BadRequest,
        //            Message = "Tham số không hợp lệ."
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResponseDto<ProductDto>
        //        {
        //            DataResponse = null,
        //            Status = StatusCodes.Status400BadRequest,
        //            Message = "Lỗi không xác định: " + ex.Message + "."
        //        };
        //    }
        //} 
    }
}
