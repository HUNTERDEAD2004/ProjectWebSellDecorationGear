﻿using AutoMapper;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DecorGearApi.Controllers.User
{
    [Route("api/user/[controller]")]
    [ApiController]
    public class KeyBoardDetailController : ControllerBase
    {
        private readonly IProductRespository _res;
        private readonly IMapper _mapper;
        public KeyBoardDetailController(IProductRespository respo, IMapper mapper)
        {
            _res = respo;
            _mapper = mapper;
        }

        // API Lấy thông tin chi tiêt bàn phím
        [HttpGet("get-keyboard-infomation")]
        public async Task<IActionResult> GetAll([FromQuery]ViewKeyBoardsDetailRequest? request, CancellationToken cancellationToken)
        {
            var result = await _res.GetAllKeyBoardDetail(request, cancellationToken);
            return Ok(result);
        }
    }
}
