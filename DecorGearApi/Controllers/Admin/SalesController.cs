using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using AutoMapper;
using DecorGearApplication.DataTransferObj.Sale;
using DecorGearApplication.Interface;

namespace DecorGearApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRespository _res;
        private readonly IMapper _mapper;

        public SalesController(ISaleRespository isaleRespository, IMapper mapper)
        {
            _res = isaleRespository;
            _mapper = mapper;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var res = await _res.GetAllSale(cancellationToken);
            return Ok(res);
        }

        [HttpGet("Get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var res = await _res.GetKeySaleById(id, cancellationToken);
            return Ok(res);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSale(CreateSaleRequest request, CancellationToken cancellationToken)
        {
            var res = await _res.CreateSale(request, cancellationToken);
            return Ok(res);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateSale(int id, UpdateSaleRequest request, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var valueID = await GetById(id, cancellationToken);
            if (valueID == null)
            {
                return NotFound("Id  không hợp lệ");
            }
            var result = await _res.UpdateSale(id, request, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSale(DeleteSaleRequest request, CancellationToken cancellationToken)
        {
            var valueID = await _res.GetKeySaleById(request.SaleID, cancellationToken);

            if (valueID == null)
            {
                return NotFound("Không tìm thấy giá trị id");
            }
            // Gọi phương thức xoá
            var result = await _res.DeleteSale(request, cancellationToken);
            return Ok(result);
        }

        [HttpGet("search")] 
        public async Task<IActionResult> SearchSale(string salename, CancellationToken cancellationToken)
        {
            var res = await _res.Search(salename, cancellationToken);
            return Ok(res);
        }
    }
}
