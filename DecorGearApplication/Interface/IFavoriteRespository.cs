using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Brand;
using DecorGearApplication.DataTransferObj.Category;
using DecorGearApplication.DataTransferObj.Favorite;
using DecorGearDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecorGearApplication.Interface
{
    public interface IFavoriteRespository
    {
        Task<List<FavoriteDto>> GetAllCategory(CancellationToken cancellationToken);
        Task<FavoriteDto> GetCategoryById(int id, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateFavorite(CreateFavoriteRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteFavorite(int id, CancellationToken cancellationToken);
    }
}
