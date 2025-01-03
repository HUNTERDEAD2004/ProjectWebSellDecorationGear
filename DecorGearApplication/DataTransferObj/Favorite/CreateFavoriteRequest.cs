using DecorGearDomain.Enum;

namespace DecorGearApplication.DataTransferObj.Favorite
{
    public class CreateFavoriteRequest
    {
        public int UserID { get; set; }

        public int ProductID { get; set; }

        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
}
