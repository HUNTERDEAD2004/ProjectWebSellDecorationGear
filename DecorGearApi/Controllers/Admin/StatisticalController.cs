using DecorGearApplication.DataTransferObj.RevenueProduct;
using DecorGearApplication.Interface;
using DecorGearInfrastructure.Database.AppDbContext;
using DecorGearInfrastructure.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DecorGearApi.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticalController : ControllerBase
    {
        private readonly IRevenueProductRepo _sttRepo;
        public StatisticalController(IRevenueProductRepo revenueProductRepo)
        {
            _sttRepo = revenueProductRepo;
        }
        //tính doanh thu theo sản phẩm
        [HttpGet("listdto")]
        public async Task<ActionResult> listdto([FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var byProduct = await _sttRepo.listdto(start, end);
            var data = byProduct.ToList();

            return Ok(data);
        }
        // tính tổng + hiển thị sản phẩm
        [HttpGet("GetTotalQuantitySold")]
        public async Task<ActionResult<(List<RevenueProductDto>, double)>> GetTotalQuantitySold([FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            try
            {
                var (productSales, totalRevenuee) = await _sttRepo.GetTotalQuantitySold(start, end);
                return Ok((productSales, totalRevenuee));
            }
            catch (Exception ex)
            {
                return NotFound("Không tìm thấy tài nguyên yêu cầu.");
            }
        }
        // tính tổng số lượng 
        [HttpGet("GetTotalQuantity")]
        public async Task<ActionResult<int>> GetTotalQuantitya([FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var totalQuantity = await _sttRepo.GetTotalQuantity(start, end);

            return Ok(totalQuantity);
        }

        [HttpGet("bymonth")]
        public async Task<ActionResult> Statisticsbymonth()
        {
            try
            {
                var bymonth = await _sttRepo.Statisticsallbymonth();
                return Ok(bymonth);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Đã xảy ra sự cố, vui lòng thử lại : {ex.Message}");
            }

        }
        // xuất file excel
        [HttpGet("byexcel")]
        public async Task<ActionResult> StatisticsRevenueExcel([FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var exe = await _sttRepo.StatisticsRevenueExcel(start, end);
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var fileName = "StatisticsRevenue.xlsx";
            return File(exe, contentType, fileName);
        }
    }
}
