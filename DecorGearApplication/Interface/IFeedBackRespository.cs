using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IFeedBackRespository
    {
        Task<List<FeedBackDto>> GetAllFeedBack(CancellationToken cancellationToken);
        Task<FeedBackDto> GetFeedBackById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateFeedBack(CreateFeedBackRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateFeedBack(FeedBackDto request, CancellationToken cancellationToken);
        Task<bool> DeleteFeedBack(int id, CancellationToken cancellationToken);
    }
}
