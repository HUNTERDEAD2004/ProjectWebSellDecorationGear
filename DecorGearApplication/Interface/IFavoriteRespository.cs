using DecorGearApplication.DataTransferObj;
using DecorGearApplication.DataTransferObj.Favorite;
using DecorGearDomain.Enum;

namespace DecorGearApplication.Interface
{
    public interface IFavoriteRespository
    {
        Task<List<FavoriteDto>> GetAllCategory(CancellationToken cancellationToken);
        Task<FavoriteDto> GetCategoryById(ViewFavoriteRequest request, CancellationToken cancellationToken);
        Task<ErrorMessage> CreateFavorite(CreateFavoriteRequest request, CancellationToken cancellationToken);
        Task<bool> DeleteFavorite(DeleteFavoriteRequest request, CancellationToken cancellationToken);
    }
}
