using DecorGearApplication.DataTransferObj.Product;
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
        // đưa ra tổng số lượng 
        public async Task<object> GetAllSoldProducts()
        {

            //var listorde = _context.OrderDetails.AsNoTracking();

            //var productSales = await listorde
            //    .GroupBy(o => o.ProductID)
            //    .Select(g => new RevenueProductDto
            //    {

            //        TotalQuantity = g.Sum(x => x.Quantity), // Tổng số lượng bán
            //        TotalRevenue = g.Sum(x => x.UnitPrice * x.Quantity) // Tổng doanh thu
            //    }).ToListAsync();
            var listorde = _context.OrderDetails.AsNoTracking();
            var listproduct = _context.Products.AsNoTracking();

            var productSales = await listorde.Join(listproduct, o => o.ProductID, p => p.ProductID, (o, p) => new { o, p })
                .GroupBy(x => new { x.p.ProductID, x.p.ProductName })
                .OrderByDescending(x => x.Sum(g => g.o.UnitPrice * g.o.Quantity))
                .Select(g => new ProductSaleDto
                {
                    Name = g.Key.ProductName,
                    ProductCode = g.Key.ProductID,
                    TotalQuantity = g.Sum(x => x.o.Quantity), // Tổng số lượng bán
                    TotalAmount = g.Sum(x => x.o.UnitPrice * x.o.Quantity) // tổng tiền
                }).ToListAsync();   

            var totalSummary = new
            {
                TotalQuantity = productSales.Sum(x => x.TotalQuantity),
                TotalAmount = productSales.Sum(x => x.TotalAmount)
            };

            return new
            {
                Data = productSales, // Chi tiết từng sản phẩm
                Summary = totalSummary // Tổng hợp
            };
        }
        //doanh thu theo sản phẩm
        public async Task<List<ProductSaleDto>> listdto(DateTime? start, DateTime? end)
        {
            //var listorde = _context.OrderDetails.AsNoTracking();
            //var listproduct = _context.Products.AsNoTracking();
            //var query = await listorde.Join(listproduct, o => o.ProductID, p => p.ProductID, (o, p) => new { o, p })
            //.Where(x => x.o.CreatedTime >= start && x.o.CreatedTime <= end)
            //.GroupBy(x => x.p.ProductID)
            //.OrderByDescending(x => x.Sum(x => x.o.UnitPrice))
            //.Select(x => new RevenueProductDto
            //{
            //    Name = x.FirstOrDefault().p.ProductName,
            //    TotalProducr = x.Sum(x => x.o.Quantity), // Tính tổng số lượng sản phẩm
            //    TotalRevenue = x.Sum(x => x.o.UnitPrice * x.o.Quantity) // Tính tổng doanh thu
            //}).ToListAsync();

            //return query;

            var listord = _context.OrderDetails.AsNoTracking();
            var listproduct = _context.Products.AsNoTracking();
            var productSales = await listord
                .Where(o => (!start.HasValue || o.CreatedTime >= start) && (!end.HasValue || o.CreatedTime <= end)) // lọc theo thời gian
                .Join(listproduct, o => o.ProductID, p => p.ProductID, (o, p) => new { o, p })
                .GroupBy(x => new { x.p.ProductID, x.p.ProductName })
                .OrderByDescending(x => x.Sum(g => g.o.UnitPrice * g.o.Quantity))
                .Select(g => new ProductSaleDto
                {
                    Name = g.Key.ProductName,
                    ProductCode = g.Key.ProductID,
                    TotalAmount = g.Sum(x => x.o.UnitPrice * x.o.Quantity), // Tổng doang thu
                    TotalQuantity = g.Sum(x => x.o.Quantity),// số lượng
                    StartDate = start ?? DateTime.MinValue, // Nếu start không có giá trị, sử dụng giá trị mặc định
                    EndDate = end ?? DateTime.MaxValue // Nếu end không có giá trị, sử dụng giá trị mặc định
                }).ToListAsync();
            return productSales;
        }

        //Đưa ra danh sách Tổng sản phẩm and tiền
        public async Task<(List<RevenueProductDto>, double)> GetTotalQuantitySold(DateTime? start, DateTime? end)
        {
            var listorde = _context.OrderDetails.AsNoTracking();
            var listproduct = _context.Products.AsNoTracking();

            // Kiểm tra giá trị start và end
            if (!start.HasValue || !end.HasValue)
            {
                throw new ArgumentException("Tham số thời gian không hợp lệ.");
            }

            var productSales = await listorde.Join(listproduct, o => o.ProductID, p => p.ProductID, (o, p) => new { o, p })
                .Where(x => x.o.CreatedTime >= start && x.o.CreatedTime <= end)
                .GroupBy(x => new { x.p.ProductID, x.p.ProductName })
                .OrderByDescending(x => x.Sum(g => g.o.UnitPrice * g.o.Quantity))
                .Select(g => new RevenueProductDto
                {
                    Name = g.Key.ProductName,
                    TotalProducr = g.Sum(x => x.o.Quantity),
                    TotalRevenue = g.Sum(x => x.o.UnitPrice * x.o.Quantity)
                }).ToListAsync();

            // Kiểm tra xem có dữ liệu trả về không
            if (productSales == null || !productSales.Any())
            {
                throw new Exception("Không có dữ liệu cho khoảng thời gian đã chọn.");
            }

            double totalRevenue = productSales.Sum(x => x.TotalRevenue.GetValueOrDefault());
            return (productSales, totalRevenue);
        }
        // đưa ra tổng số lượng :))
        public async Task<int> GetTotalQuantity(DateTime? start, DateTime? end)
        {
            // Truy vấn OrderDetails để lấy tổng số lượng sản phẩm đã bán trong khoảng thời gian
            var totalQuantity = await _context.OrderDetails
                .AsNoTracking()
                .Where(o => o.CreatedTime >= start && o.CreatedTime <= end)
                .SumAsync(o => o.Quantity);

            return totalQuantity;
        }

        // doanh thu tháng
        public async Task<CountByMonth> Statisticsallbymonth()
        {
            var list = _context.Orders.AsNoTracking();
            var month = DateTime.Now.Month;
            var day = DateTime.Now.Date;

            var countQuatityByMonth = await list.Where(x => x.CreatedTime.Month == month && x.CreatedTime.Year == DateTime.Now.Year).CountAsync();
            var totalQuatityByMonth = await list.Where(x => x.CreatedTime.Month == month && x.CreatedTime.Year == DateTime.Now.Year).SumAsync(p => p.totalPrice);
            var revenueNow = await list.Where(x => x.CreatedTime.Date == day && x.CreatedTime.Year == DateTime.Now.Year).SumAsync(p => p.totalPrice);
            return new CountByMonth()
            {
                CountQuatityByMonth = countQuatityByMonth,
                TotalQuatityByMonth = totalQuatityByMonth,
                RevenueNow = revenueNow,
            };
        }
        // xuất file excel
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
                    sheet.Cells[i + 2, 2].Value = data[i].TotalQuantity;
                    sheet.Cells[i + 2, 3].Value = data[i].TotalAmount;
                }
                sheet.Cells[sheet.Dimension.Address].AutoFitColumns();//điều chỉnh cột tự động
                return package.GetAsByteArray();// ghi file
            }
        }
    }
}
