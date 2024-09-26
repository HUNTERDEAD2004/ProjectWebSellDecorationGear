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
