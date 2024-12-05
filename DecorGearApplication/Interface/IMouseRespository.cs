using DecorGearApplication.DataTransferObj.MouseDetails;
using DecorGearApplication.ValueObj.Response;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IMouseRespository
    {
        Task<List<MouseDetailsDto>> GetAllMouse(ViewMouseRequest? request, CancellationToken cancellationToken);
        Task<MouseDetailsDto> GetMouseById(int id, CancellationToken cancellationToken);
        Task<ResponseDto<MouseDetailsDto>> CreateMouse(CreateMouseRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<MouseDetailsDto>> UpdateMouse(int id, UpdateMouseRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteMouse(int id, CancellationToken cancellationToken);
    }
}
