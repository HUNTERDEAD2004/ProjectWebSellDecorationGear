using AutoMapper;
using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace DecorGearInfrastructure.Implement
{
    public class MouseRespository : IMouseRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public MouseRespository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<ErrorMessage> CreateMouse(CreateMouseRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var createMouse = _mapper.Map<MouseDetailsDto>(request);

                _appDbContext.Add(createMouse);

                _appDbContext.SaveChanges();

                return ErrorMessage.Successfull;
            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteMouse(int id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.MouseDetails.FindAsync(id, cancellationToken);
            if (keyResult != null)
            {
                _appDbContext.MouseDetails.Remove(keyResult);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<MouseDetailsDto>> GetAllMouse(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.MouseDetails.ToListAsync(cancellationToken);

            return _mapper.Map<List<MouseDetailsDto>>(result);
        }

        public async Task<MouseDetailsDto> GetMouseById(int id, CancellationToken cancellationToken)
        {
            var keyResult = await _appDbContext.MouseDetails.FindAsync(id, cancellationToken);

            return _mapper.Map<MouseDetailsDto>(keyResult);
        }

        public async Task<ErrorMessage> UpdateMouse(int id, UpdateMouseRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            try
            {
                var mouse = await _appDbContext.MouseDetails.FindAsync(id);

                mouse.ProductID = request.ProductID;
                mouse.Color = request.Color;
                mouse.DPI = request.DPI;
                mouse.Connectivity = request.Connectivity;
                mouse.Dimensions = request.Dimensions;
                mouse.Material = request.Material;
                mouse.EyeReading = request.EyeReading;
                mouse.Button = request.Button;
                mouse.LED = request.LED;
                mouse.SS = request.SS;

                _appDbContext.Update(mouse);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;

            }
            catch (Exception)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}
