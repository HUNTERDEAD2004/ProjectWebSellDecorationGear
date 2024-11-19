using AutoMapper;
using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.User;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace DecorGearInfrastructure.Implement
{
    public class FeedBackRepository : IFeedBackRespository
    {
        private readonly AppDbContext _db;
        private readonly IMapper _map;
        public FeedBackRepository(AppDbContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }
        public async Task<ResponseDto<ErrorMessage>> CreateFeedBack(CreateFeedBackRequest request, CancellationToken cancellationToken)
        {
            var feedback = _map.Map<FeedBack>(request);
            await _db.FeedBacks.AddAsync(feedback);
            await _db.SaveChangesAsync(cancellationToken);

            return new ResponseDto<ErrorMessage>(StatusCodes.Status201Created, "Feedback được tạo thành công");
        }

        public async Task<ResponseDto<bool>> DeleteFeedBack(DeleteFeedBackRequest request, CancellationToken cancellationToken)
        {

            var feedback = await _db.FeedBacks.FindAsync(request.FeedBackID, cancellationToken);
            if (feedback == null)
            {
                return new ResponseDto<bool>(StatusCodes.Status404NotFound, "Feedback không tồn tại.");
            }
            _db.FeedBacks.Remove(feedback);
            await _db.SaveChangesAsync(cancellationToken);

            return new ResponseDto<bool>(StatusCodes.Status200OK, "Xóa FeedBack Thành Công");
        }

        public async Task<List<FeedBackDto>> GetAllFeedBack(int pageNumber, int pageSize)
        {
            var feedback = await _db.FeedBacks
                .OrderBy(u => u.FeedBackID) 
                .Skip((pageNumber - 1) * pageSize) 
                .Take(pageSize) 
                .ToListAsync();

            return _map.Map<List<FeedBackDto>>(feedback);
        }


        public async Task<FeedBackDto> FeedBackById(int id, CancellationToken cancellationToken)
        {
            var feedbackbyid = await _db.FeedBacks.FindAsync(id, cancellationToken);
            return _map.Map<FeedBackDto>(feedbackbyid);
        }

        public async Task<ResponseDto<ErrorMessage>> UpdateFeedBack(int id, UpdateFeedBackRequest request, CancellationToken cancellationToken)
        {
            var feedback = await _db.FeedBacks.FindAsync(id, cancellationToken);
            if (feedback == null)
                return new ResponseDto<ErrorMessage>(StatusCodes.Status404NotFound, "Feedback không tồn tại.");

            _map.Map(request, feedback);
            _db.FeedBacks.Update(feedback);
            await _db.SaveChangesAsync(cancellationToken);

            return new ResponseDto<ErrorMessage>(StatusCodes.Status200OK, "Feedback đã được cập nhật thành công.");
        }
    }
}

