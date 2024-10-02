using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearDomain.Enum;
using Ecommerce.Application.DataTransferObj.User.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface ICartRespository
    {
        Task<List<CartDto>> GetAllCart(CancellationToken cancellationToken);
        Task<CartDto> GetCartById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> AddProductToCart(CreateCartDetailRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteCart(DeleteCartRequest request, CancellationToken cancellationToken);
    }
}
