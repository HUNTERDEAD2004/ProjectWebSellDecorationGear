using DecorGearApplication.DataTransferObj.Product;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IProductRespository
    {
        Task<List<ProductDto>> GetAllProduct(CancellationToken cancellationToken);
        Task<ProductDto> GetKeyProductById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateProduct(int id, UpdateProductRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(int id, CancellationToken cancellationToken);
    }
}
