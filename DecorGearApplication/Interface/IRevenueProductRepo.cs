using DecorGearApplication.DataTransferObj.Product;
using DecorGearApplication.DataTransferObj.RevenueProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IRevenueProductRepo
    {
        //Task<List<RevenueProductDto>> GetAll(CancellationToken cancellationToken);
        //Task<List<ProductSaleDto>> GetAllSoldProducts();
        Task<object> GetAllSoldProducts();
       //Task<List<RevenueProductDto>> listdto(DateTime? start, DateTime? end);
       Task<List<ProductSaleDto>> listdto(DateTime? start, DateTime? end);
        Task<CountByMonth> Statisticsallbymonth();
        Task<byte[]> StatisticsRevenueExcel(DateTime? start, DateTime? end);
        Task<(List<RevenueProductDto>, double)> GetTotalQuantitySold(DateTime? start, DateTime? end);
        Task<int> GetTotalQuantity(DateTime? start, DateTime? end);
    }
}
