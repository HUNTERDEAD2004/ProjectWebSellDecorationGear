using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.DataTransferObj.CartDetail;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;

namespace DecorGearApplication.Services
{
    public class CartService
    {
        private readonly ICartRespository _cartRepository;
        private readonly ICartDetailRespository _cartDetailRepository;
        private readonly IProductRespository _productRepository;

        public CartService(ICartRespository cartRepository, ICartDetailRespository cartDetailRepository, IProductRespository productRepository)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<CartDetailsResponse> AddProductsToCart(List<CreateCartDetailRequest> requests, CancellationToken cancellationToken)
        {
            if (requests == null || requests.Count == 0)
                throw new ArgumentException("Danh sách sản phẩm không thể rỗng hoặc null.");

            var cart = await _cartRepository.GetCartByUserId(requests[0].UserID)
                ?? new Cart
                {
                    UserID = requests[0].UserID,
                    TotalQuantity = 0,
                    TotalAmount = 0.0,
                    CreatedBy = requests[0].UserID,
                    CreatedTime = DateTime.Now,
                    CartDetails = new List<CartDetail>()
                };

            foreach (var request in requests)
            {
                if (request.Quantity <= 0 || request.UnitPrice <= 0)
                    throw new ArgumentException("Số lượng và giá sản phẩm phải có giá trị dương.");

                var existingCartDetail = cart.CartDetails.FirstOrDefault(item => item.ProductID == request.ProductID);
                if (existingCartDetail != null)
                {
                    existingCartDetail.Quantity += request.Quantity;
                    existingCartDetail.TotalPrice = existingCartDetail.Quantity * existingCartDetail.UnitPrice;
                }
                else
                {
                    var product = await _productRepository.GetProductById(request.ProductID);
                    if (product == null)
                        throw new ArgumentException($"Không tìm thấy sản phẩm với mã ID {request.ProductID}.");

                    var newCartDetail = new CartDetail
                    {
                        CartID = cart.CartID,
                        ProductID = request.ProductID,
                        Quantity = request.Quantity,
                        UnitPrice = (double)request.UnitPrice,
                        TotalPrice = request.Quantity * (double)request.UnitPrice,
                    };
                    cart.CartDetails.Add(newCartDetail);
                }
            }

            // Cập nhật tổng số lượng và tổng tiền cho giỏ hàng
            var totalItems = cart.CartDetails.Count;
            cart.TotalQuantity = cart.CartDetails.Sum(cd => cd.Quantity);
            cart.TotalAmount = cart.CartDetails.Sum(cd => cd.TotalPrice);

            if (cart.CartID == 0)
                await _cartRepository.CreateAsync(cart, cancellationToken);
            else
                await _cartRepository.UpdateAsync(cart, cancellationToken);

            var cartDetailsResponse = new CartDetailsResponse
            {
                TotalAmount = cart.TotalAmount,
                TotalItems = totalItems,
                Products = new List<CartProductDetail>()
            };

            foreach (var cartDetail in cart.CartDetails)
            {
                var product = await _productRepository.GetProductById(cartDetail.ProductID);
                if (product != null)
                {
                    cartDetailsResponse.Products.Add(new CartProductDetail
                    {
                        ProductName = product.ProductName,
                        Quantity = cartDetail.Quantity,
                        UnitPrice = cartDetail.UnitPrice,
                        TotalPrice = cartDetail.TotalPrice
                    });
                }
                else
                {
                    throw new ArgumentException($"Không tìm thấy thông tin sản phẩm với mã ID {cartDetail.ProductID}.");
                }
            }

            return cartDetailsResponse;
        }
    }
}

