using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.Interface;
using DecorGearApplication.IServices;
using DecorGearDomain.Enum;


namespace DecorGearApplication.Services
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IFeedBackRespository _feedBackRespository;
        public FeedbackServices(IFeedBackRespository feedBackRespository)
        {
            _feedBackRespository = feedBackRespository;
        }
        public async Task<ResponseDto<ErrorMessage>> CreateFeedBack(CreateFeedBackRequest request, CancellationToken cancellationToken)
        {
            return await _feedBackRespository.CreateFeedBack(request, cancellationToken);
        }

        public async Task<ResponseDto<bool>> DeleteFeedBack(DeleteFeedBackRequest request, CancellationToken cancellationToken)
        {
            return await _feedBackRespository.DeleteFeedBack(request, cancellationToken);
        }

        public async Task<List<FeedBackDto>> GetAllFeedBack(CancellationToken cancellationToken)
        {
            return await _feedBackRespository.GetAllFeedBack(cancellationToken);
        }

        public async Task<FeedBackDto> FeedBackById(int id, CancellationToken cancellationToken)
        {
            return await _feedBackRespository.FeedBackById(id, cancellationToken);
        }

        public async Task<ResponseDto<ErrorMessage>> UpdateFeedBack(int id, UpdateFeedBackRequest request, CancellationToken cancellationToken)
        {
            return await _feedBackRespository.UpdateFeedBack(id, request, cancellationToken);
        }
    }
}
