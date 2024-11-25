using AutoMapper;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.User
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class MouseDetailController : ControllerBase
    {
        private readonly IProductRespository _res;
        private readonly IMapper _mapper;
        public MouseDetailController(IProductRespository respo, IMapper mapper)
        {
            _res = respo;
            _mapper = mapper;
        }

        // API Lấy thông tin chi tiêt bàn phím
        [HttpGet("get-mouse-infomation")]
        public async Task<IActionResult> GetAll([FromQuery] ViewMouseDetailRequest? request, CancellationToken cancellationToken)
        {
            var result = await _res.GetAllMouseDetail(request, cancellationToken);
            return Ok(result);
        }
    }
}
