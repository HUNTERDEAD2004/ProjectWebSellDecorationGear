using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IImageListRespository
    {
        Task<List<ImageListDto>> GetAllImage(CancellationToken cancellationToken);
        Task<ImageListDto> GetImageById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateImage(CreateImageRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> UpdateImage(int id, UpdateImageListRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteImage(int id, CancellationToken cancellationToken);
        public bool IsValidImageFormat(List<string> imagePaths);
    }
}
