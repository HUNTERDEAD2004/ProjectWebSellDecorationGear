using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj.FeedBack;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.ValueObj.Response;
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
        Task<ResponseDto<ImageListDto>> CreateImage(CreateImageRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<ImageListDto>> UpdateImage(int id, UpdateImageListRequest request, CancellationToken cancellationToken);
        Task<ResponseDto<bool>> DeleteImage(int id, CancellationToken cancellationToken);
        public bool IsValidImageFormat(string imagePaths);
    }
}
