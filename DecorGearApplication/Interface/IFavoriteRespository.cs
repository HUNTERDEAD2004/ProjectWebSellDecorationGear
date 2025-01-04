using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Favorite;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IFavoriteRespository
    {
        Task<List<FavoriteDto>> GetAllCategory(CancellationToken cancellationToken);
        Task<FavoriteDto> GetCategoryById(CancellationToken cancellationToken);
        Task<ErrorMessage> CreateFavorite(CreateFavoriteRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteFavorite(int id, CancellationToken cancellationToken);
    }
}
