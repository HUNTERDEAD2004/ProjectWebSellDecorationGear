using DecorGearApplication.DataTransferObj.Cart;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApplication.Services;

public class CartService
{
    private readonly ICartRespository _cartRepository;
    private readonly ICartDetailRespository _cartDetailRepository;

    public CartService(ICartRespository cartRepository, ICartDetailRespository cartDetailRepository)
    {
        _cartRepository = cartRepository;
        _cartDetailRepository = cartDetailRepository;
    }

    public async Task<bool> AddProductToCart(AddToCartRequest request)
    {
        // Kiểm tra giỏ hàng của người dùng
        var cart = await _cartRepository.GetCartByUserId(request.UserId);
        if (cart == null)
        {
            // Nếu chưa có giỏ hàng, tạo giỏ hàng mới
            cart = new Cart
            {
                UserID = request.UserId,
                TotalQuantity = 0,
                TotalAmount = 0.0,
                CreatedBy = request.UserId,
                CreatedTime = DateTime.Now
            };
            await _cartRepository.CreateAsync(cart);
        }

        // Kiểm tra sản phẩm trong giỏ hàng
        var cartDetail = await _cartDetailRepository.GetCartDetailByCartIdAndProductId(cart.CartID, request.ProductId);
        if (cartDetail != null)
        {
            // Cập nhật số lượng sản phẩm
            cartDetail.Quantity += request.Quantity;
            cartDetail.TotalPrice = cartDetail.Quantity * cartDetail.UnitPrice;
            await _cartDetailRepository.UpdateAsync(cartDetail);
        }
        else
        {
            if (request.UnitPrice <= 0)
            {
                throw new ArgumentException("Unit price must be a positive value.");
            }

            // Thêm sản phẩm mới vào giỏ
            cartDetail = new CartDetail
            {
                CartID = cart.CartID,
                ProductID = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                TotalPrice = request.Quantity * request.UnitPrice
            };
            await _cartDetailRepository.CreateAsync(cartDetail);
        }

        // Cập nhật tổng số lượng và tổng tiền của giỏ hàng
        cart.TotalQuantity = await _cartDetailRepository.GetTotalQuantity(cart.CartID);
        cart.TotalAmount = await _cartDetailRepository.GetTotalAmount(cart.CartID);
        await _cartRepository.UpdateAsync(cart);

        return true;
    }

}
