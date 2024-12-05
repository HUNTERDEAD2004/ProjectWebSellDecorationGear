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

        // API lấy tất cả sản phẩm đã bán
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllSoldProducts()
        {
            try
            {
                var result = await _sttRepo.GetAllSoldProducts();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message }); 
            }
        }


        //hiển thị doanh thu và tìm kiếm theo thời gian
        [HttpGet("listdto")]
        public async Task<ActionResult> listdto([FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            try
            {
                //không có tham số start và end, trả về toàn bộ dữ liệu
                if (!start.HasValue && !end.HasValue)
                {
                    var allProducts = await _sttRepo.GetAllSoldProducts();
                    return Ok(allProducts);
                }

                //có tham số, trả về dữ liệu đã lọc theo thời gian
                var filteredProducts = await _sttRepo.listdto(start, end);
                return Ok(filteredProducts);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
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
