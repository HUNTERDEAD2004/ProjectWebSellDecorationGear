using DecorGearApplication.DataTransferObj.Address;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DecorGearApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        //Lưu thông tin địa chỉ
        [HttpPost]
        public async Task<IActionResult> SaveAddress([FromBody] AddressDto address)
        {
            var savedAddress = await _addressRepository.SaveAddressAsync(address);
            return Ok(savedAddress);
        }

        //Lấy thông tin địa chỉ 
        [HttpGet]
        public async Task<IActionResult> GetUserAddress()
        {
            try
            {
                var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                {
                    return BadRequest("Invalid or missing user ID.");
                }

                var address = await _addressRepository.GetAddressByUserIdAsync(userId);

                if (address == null)
                {
                    return NotFound("No address found for the specified user.");
                }

                return Ok(address);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
