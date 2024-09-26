using AutoMapper;
using AutoMapper.Execution;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.implement
{
    public class ProductRespository : IProductRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ProductRespository(AppDbContext context,IMapper mapper)
        {
            _appDbContext = context;
            _mapper = mapper;
        }
        public async Task<ErrorMessage> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            //Kiểm tra xem ProductID đã tồn tại chưa 
            if (await _appDbContext.Products.AnyAsync(m => m.ProductID == request.ProductID, cancellationToken))
            {
                return ErrorMessage.Failed;
            }

            // Thêm Sản Phẩm Mới
            try
            {
                var CreateProduct = _mapper.Map<Product>(request);

                await _appDbContext.Products.AddAsync(CreateProduct, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull; 
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed; 
            }
        }

        public async Task<bool> DeleteProduct(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var deleteProducts = await _appDbContext.Products.FindAsync(request,cancellationToken);
            if (deleteProducts != null)
            {
                _appDbContext.Products.Remove(deleteProducts);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<ProductDto>> GetAllProduct(CancellationToken cancellationToken)
        {
            var products = await _appDbContext.Products.ToListAsync(cancellationToken);

            return _mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetKeyProductById(ViewProductRequest request, CancellationToken cancellationToken)
        {
            var productIds = await _appDbContext.Products.FindAsync(request,cancellationToken);

            return _mapper.Map<ProductDto>(productIds);
        }

        public async Task<ErrorMessage> UpdateProduct(ProductDto request, CancellationToken cancellationToken)
        {

            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            //Kiểm tra xem ProductID đã tồn tại chưa 
            if (await _appDbContext.Products.AnyAsync(m => m.ProductID == request.ProductID, cancellationToken))
            {
                return ErrorMessage.Failed;
            }

            // Thêm Sản Phẩm Mới
            try
            {
                var updateProduct = new Product
                {
                    ProductID = request.ProductID,
                    ProductName = request.ProductName,
                    Price = request.Price,
                    View = request.View,
                    Quantity = request.Quantity,
                    Weight = request.Weight,
                    Description = request.Description,
                    Size = request.Size,
                    SaleID = request.SaleID,
                    BrandID = request.BrandID,
                    SubCategoryID = request.SubCategoryID,
                    OrderID = request.OrderID
                };

                _appDbContext.Products.Update(updateProduct);

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
