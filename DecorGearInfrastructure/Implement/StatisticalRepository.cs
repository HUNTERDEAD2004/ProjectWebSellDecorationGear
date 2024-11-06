using DecorGearApplication.DataTransferObj.RevenueProduct;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class StatisticalRepository : IRevenueProductRepo
    {
        private readonly AppDbContext _context;

        public StatisticalRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        //doanh thu theo sản phẩm
        public async Task<List<RevenueProductDto>> listdto(DateTime? start, DateTime? end)
        {
            var listorde = _context.OrderDetails.AsNoTracking();
            var listproduct = _context.Products.AsNoTracking();
            var query = await listorde.Join(listproduct, o => o.ProductID, p => p.ProductID, (o, p) => new { o, p })
            .Where(x => x.o.CreatedTime >= start && x.o.CreatedTime <= end)
            .GroupBy(x => x.p.ProductID)
            .OrderByDescending(x => x.Sum(x => x.o.UnitPrice))
            .Select(x => new RevenueProductDto
            {
                Name = x.FirstOrDefault().p.ProductName,
                TotalProducr = x.Count(),
                TotalRevenue = x.Sum(x => x.o.UnitPrice)
            }).ToListAsync();

            return query.ToList();
        }
        // doanh thu tháng
        public async Task<RevenueProductDto> Statisticsallbymonth()
        {
            var list = _context.Orders.AsNoTracking();
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Date;

            var countQuatityByMonth = await list.Where(x => x.CreatedTime.Month == month && x.CreatedTime.Year == DateTime.Now.Year).CountAsync();
            var totalQuatityByMonth = await list.Where(x => x.CreatedTime.Month == month && x.CreatedTime.Year == DateTime.Now.Year).SumAsync(p => p.totalPrice);
            var revenueNow = await list.Where(x => x.CreatedTime.Date == day && x.CreatedTime.Year == DateTime.Now.Year).SumAsync(p => p.totalPrice);
            return new RevenueProductDto()
            {
                CountQuatityByMonth = countQuatityByMonth,
                TotalQuatityByMonth = totalQuatityByMonth,
                RevenueNow = revenueNow,
            };
        }
        public async Task<byte[]> StatisticsRevenueExcel(DateTime? start, DateTime? end)
        {
            var res = await listdto(start, end);
            var data = res.ToList();
            if (res == null || !res.Any())
            {
                // Xử lý nếu không có dữ liệu
                throw new Exception("Không có dữ liệu để xuất ra Excel.");
            }
            //tạo file
            using (var package = new ExcelPackage())
            {
                //thêm tiêu đề
                var sheet = package.Workbook.Worksheets.Add("Revenue");

                sheet.Cells[1, 1].Value = "Tên sản phẩm";
                sheet.Cells[1, 2].Value = "số sản phẩm bán";
                sheet.Cells[1, 3].Value = "Tông tiền sản phẩm";

                for (int i = 0; i < data.Count; i++)
                {
                    sheet.Cells[i + 2, 1].Value = data[i].Name;
                    sheet.Cells[i + 2, 2].Value = data[i].TotalProducr;
                    sheet.Cells[i + 2, 3].Value = data[i].TotalRevenue;
                }
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();//điều chỉnh cột tự động
                return package.GetAsByteArray();// ghi file
            }
        }
    }
}
