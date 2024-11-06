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

        [HttpGet("listdto")]
        public async Task<ActionResult> listdto([FromQuery] DateTime? start, [FromQuery] DateTime? end)
        {
            var byProduct = await _sttRepo.listdto(start, end);
            var data = byProduct.ToList();

            return Ok(data);
        }
        [HttpGet("bymonth")]
        public async Task<ActionResult> Statisticsbymonth()
        {
            var bymonth = await _sttRepo.Statisticsallbymonth();
            return Ok(bymonth);
        }
        [HttpGet("byexcel")]
        public async Task<ActionResult> StatisticsRevenueExcel([FromQuery] DateTime? start,[FromQuery] DateTime? end)
        {
            var exe = await _sttRepo.StatisticsRevenueExcel(start, end);
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            var fileName = "StatisticsRevenue.xlsx";
            return File(exe, contentType, fileName);
        }
    }
}
