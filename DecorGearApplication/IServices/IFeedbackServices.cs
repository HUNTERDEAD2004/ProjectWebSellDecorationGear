using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
using DecorGearDomain.Enum;

namespace DecorGearApplication.IServices
{
    public interface IFeedbackServices
    {
        Task<List<FeedBackDto>> GetAllFeedBack(CancellationToken cancellationToken);
        Task<FeedBackDto> FeedBackById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> CreateFeedBack(CreateFeedBackRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<ErrorMessage>> UpdateFeedBack(int id, UpdateFeedBackRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteFeedBack(DeleteFeedBackRequest request, CancellationToken cancellationToken);
    }
}
