using AutoMapper;
using DecorGearApplication.DataTransferObj.ImageList;
using DecorGearApplication.DataTransferObj.KeyBoardDetails;
using DecorGearApplication.Interface;
using DecorGearDomain.Data.Entities;
using DecorGearDomain.Enum;
using DecorGearInfrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearInfrastructure.Implement
{
    public class ImageListRespository : IImageListRespository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public ImageListRespository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<ErrorMessage> CreateImage(CreateImageRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }
            // Thêm Sản Phẩm Mới
            try
            {
                if (!IsValidImageFormat(request.ImagePath))
                {
                    return ErrorMessage.Failed;
                }
                var createImageList = _mapper.Map<ImageList>(request);

                await _appDbContext.ImageLists.AddAsync(createImageList, cancellationToken);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }

        public async Task<bool> DeleteImage(int id, CancellationToken cancellationToken)
        {
            var deleteImageList = await _appDbContext.ImageLists.FindAsync(id, cancellationToken);
            if (deleteImageList != null)
            {
                _appDbContext.ImageLists.Remove(deleteImageList);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<ImageListDto>> GetAllImage(CancellationToken cancellationToken)
        {
            var imageLists = await _appDbContext.ImageLists.ToListAsync(cancellationToken);

            return _mapper.Map<List<ImageListDto>>(imageLists);
        }

        public async Task<ImageListDto> GetImageById(int id, CancellationToken cancellationToken)
        {
            var imageLists = await _appDbContext.ImageLists.FindAsync(id, cancellationToken);

            return _mapper.Map<ImageListDto>(imageLists);
        }

        public bool IsValidImageFormat(List<string> imagePaths)
        {
            // Các định dạng hợp lệ
            var validExtensions = new List<string> { ".jpg", ".jpeg" };

            // Kiểm tra từng đường dẫn
            foreach (var imagePath in imagePaths)
            {
                // Lấy phần mở rộng của tệp
                var extension = Path.GetExtension(imagePath)?.ToLower();

                // Nếu phần mở rộng không hợp lệ, trả về false
                if (!validExtensions.Contains(extension))
                {
                    return false;
                }
            }

            // Tất cả các tệp đều hợp lệ
            return true;
        }

        public async Task<ErrorMessage> UpdateImage(int id, UpdateImageListRequest request, CancellationToken cancellationToken)
        {
            // Kiểm Tra Tính Hợp Lệ của Dữ Liệu
            if (request == null)
            {
                return ErrorMessage.Failed;
            }

            // Cập Nhật Sản Phẩm 
            try
            {
                var imageList = await _appDbContext.ImageLists.FindAsync(id);

                imageList.ImagePath = request.ImagePath;
                imageList.ProductID = request.ProductID;
                imageList.Description = request.Description;

                _appDbContext.ImageLists.Update(imageList);

                await _appDbContext.SaveChangesAsync(cancellationToken);

                return ErrorMessage.Successfull;
            }
            catch (Exception ex)
            {
                return ErrorMessage.Failed;
            }
        }
    }
}
