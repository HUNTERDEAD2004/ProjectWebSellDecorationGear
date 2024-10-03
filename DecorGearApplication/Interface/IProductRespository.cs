using DecorGearApplication.DataTransferObj.Product;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IProductRespository
    {
        Task<List<ProductDto>> GetAllProduct(CancellationToken cancellationToken);
        Task<ProductDto> GetKeyProductById(Guid id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateProduct(ProductDto request, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(Guid id, CancellationToken cancellationToken);
    }
}
