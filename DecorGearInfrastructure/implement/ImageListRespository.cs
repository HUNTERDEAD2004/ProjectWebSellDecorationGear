using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.Interface;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.implement
{
    public class ImageListRespository : IImageListRespository
    {
        //public bool ValidateImagePath(string path)
        //{
        //    // Kiểm tra xem đường dẫn có phải là đường dẫn tuyệt đối
        //    if (!Path.IsPathRooted(path))
        //    {
        //        throw new ArgumentException("Đường dẫn ảnh phải là đường dẫn tuyệt đối.");
        //    }

        //    // Kiểm tra định dạng của đường dẫn (ví dụ: chỉ chấp nhận .jpg và .png)
        //    string extension = Path.GetExtension(path);
        //    if (string.IsNullOrEmpty(extension) ||
        //        (extension != ".jpg" && extension != ".png"))
        //    {
        //        throw new ArgumentException("Định dạng ảnh không hợp lệ. Chỉ chấp nhận .jpg và .png.");
        //    }

        //    // Đường dẫn hợp lệ
        //    return true;
        //}

        public Task<ErrorMessage> CreateImage(CreateImageRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImage(DeleteImageRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ImageListDto>> GetAllImage(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ImageListDto> GetImageById(ViewImageListRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ErrorMessage> UpdateImage(UpdateImageRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
