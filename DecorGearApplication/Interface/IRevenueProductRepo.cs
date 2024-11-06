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
        Task<List<RevenueProductDto>> listdto(DateTime? start, DateTime? end);
        Task<RevenueProductDto> Statisticsallbymonth();
        Task<byte[]> StatisticsRevenueExcel(DateTime? start, DateTime? end);
    }
}
