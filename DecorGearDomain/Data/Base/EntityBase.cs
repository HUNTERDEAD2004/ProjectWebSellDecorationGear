
namespace DecorGearDomain.Data.Base
{
    public class EntityBase : ICreatedBase, IModifiedBase, IDeletedBase
    {
        public Guid? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public Guid? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
