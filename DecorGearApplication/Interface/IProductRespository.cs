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
        Task<ProductDto> GetKeyProductById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateProduct(int id,UpdateProductRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(int id, CancellationToken cancellationToken);
    }
}
