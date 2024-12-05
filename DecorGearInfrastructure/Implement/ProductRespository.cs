using AutoMapper;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.Interface;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<ProductDto>> GetAllProduct(ViewProductRequest? request, CancellationToken cancellationToken)
        {
            var query = (from p in _appDbContext.Products
                        join b in _appDbContext.Brands on p.BrandID equals b.BrandID
                        join s in _appDbContext.Sales on p.SaleID equals s.SaleID into saleJoin
                        from s in saleJoin.DefaultIfEmpty() // Left join để Sale có thể null
                        join sc in _appDbContext.SubCategories on p.SubCategoryID equals sc.SubCategoryID
                        join i in _appDbContext.ImageLists on p.ProductID equals i.ProductID
                        select new ProductDto
                        {
                            ProductID = p.ProductID,
                            ProductName = p.ProductName, // Thêm ProductName
                            Price = p.Price,             // Thêm Price
                            BrandID = b.BrandID,
                            BrandName = b.BrandName,
                            SaleID = s != null ? s.SaleID : null,
                            SaleCode = s != null ? s.SaleName : null,
                            SubCategoryID = sc.SubCategoryID,
                            SubCategoryName = sc.SubCategoryName,
                            View = p.View,
                            Quantity = p.Quantity,
                            Weight = p.Weight,
                            AvatarProduct = p.AvatarProduct,
                            Description = p.Description,
                            Size = p.Size,
                            BatteryCapacity = p.BatteryCapacity,
                            ImageProduct = _appDbContext.ImageLists
                                    .Where(img => img.ProductID == p.ProductID)
                                    .Select(img => img.ImagePath)
                                    .ToList()
                        }).AsNoTracking().AsQueryable();

            // Lọc sản phẩm 
            if (request.ProductID.HasValue)
            {
                query = query.Where(x => x.ProductID == request.ProductID);
            }
            if (!string.IsNullOrEmpty(request.ProductName))
            {
                query = query.Where(x => x.ProductName == request.ProductName);
            }
            if (request.Price.HasValue)
            {
                query = query.Where(x => x.Price == request.Price);
            }
            if (request.View.HasValue)
            {
                query = query.Where(x => x.View == request.View);
            }
            if (request.Quantity.HasValue)
            {
                query = query.Where(x => x.Quantity == request.Quantity);
            }
            if (request.Weight.HasValue)
            {
                query = query.Where(x => x.Weight == request.Weight);
            }
            if (!string.IsNullOrEmpty(request.Description))
            {
                query = query.Where(x => x.Description == request.Description);
            }
            if (!string.IsNullOrEmpty(request.Size))
            {
                query = query.Where(x => x.Size == request.Size);
            }
            if (request.BatteryCapacity.HasValue)
            {
                query = query.Where(x => x.BatteryCapacity == request.BatteryCapacity);
            }

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<ProductDto> GetKeyProductById(int id, CancellationToken cancellationToken)
        {
            var productIds = await _appDbContext.Products.FindAsync(id, cancellationToken);

            return _mapper.Map<ProductDto>(productIds);
        }

        public async Task<ResponseDto<ProductDto>> UpdateProduct(int id,UpdateProductRequest request, CancellationToken cancellationToken)
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

            // Cập Nhật Sản Phẩm 
            try
            {
                var product = await _appDbContext.Products.FindAsync(id, cancellationToken);

                product.ProductName = request.ProductName;
                product.Price = request.Price;
                product.View = request.View;
                product.Quantity = request.Quantity;
                product.Weight = request.Weight;
                product.Description = request.Description;
                product.Size = request.Size;
                product.BatteryCapacity = request.BatteryCapacity;
                product.SaleID = request.SaleID;
                product.BrandID = request.BrandID;
                product.SubCategoryID = request.SubCategoryID;

                _appDbContext.Products.Update(product);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return new ResponseDto<ProductDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Chưa có request."
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseDto<ProductDto>
                {
                    DataResponse = null,
                    Status = StatusCodes.Status500InternalServerError,
                    Message = "Lỗi khi cập nhật cơ sở dữ liệu."
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
    }
}
