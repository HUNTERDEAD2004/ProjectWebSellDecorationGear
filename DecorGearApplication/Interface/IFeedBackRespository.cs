using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
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
        Task<FeedBackDto> FeedBackById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> CreateFeedBack(CreateFeedBackRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> UpdateFeedBack(int id,UpdateFeedBackRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteFeedBack(DeleteFeedBackRequest request, CancellationToken cancellationToken);
    }
}
