using AutoMapper;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
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

        public async Task<ErrorMessage> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            // Thêm Sản Phẩm Mới
            try
            {
                var createProduct = _mapper.Map<Product>(request);

                await _appDbContext.Products.AddAsync(createProduct, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            var deleteProducts = await _appDbContext.Products.FindAsync(id, cancellationToken);
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

        public async Task<ProductDto> GetKeyProductById(int id, CancellationToken cancellationToken)
        {
            var productIds = await _appDbContext.Products.FindAsync(id, cancellationToken);

            return _mapper.Map<ProductDto>(productIds);
        }

        public async Task<ErrorMessage> UpdateProduct(int id, UpdateProductRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
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

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}
