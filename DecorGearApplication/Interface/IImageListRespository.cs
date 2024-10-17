using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
