using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class CartRepository : ICartDetailRespository
    {
        public Task<ErrorMessage> CreateCartDetail(CreateCartDetailRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(DeleteCartDetailRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartDetailDto>> GetAllCartDetai(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CartDetailDto> GetCartDetailById(ViewCartRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateCartDetail(UpdateCartDetailRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
