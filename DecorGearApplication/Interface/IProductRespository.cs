using DecorGearApplication.DataTransferObj.Order;
using DecorGearApplication.DataTransferObj.Product;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    internal interface IProductRespository
    {
        Task<List<ProductDto>> GetAllProduct(CancellationToken cancellationToken);
        Task<ProductDto> GetKeyProductById(ViewProductRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateProduct(CreateProductRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateProduct(UpdateProductRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteProduct(DeleteProductRequest request, CancellationToken cancellationToken);
    }
}
