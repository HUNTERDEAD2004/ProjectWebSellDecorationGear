namespace DecorGearDomain.Data.Base
{
    public class EntityBase : ICreatedBase, IModifiedBase, IDeletedBase
    {
        public int? CreatedBy { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
        public int? ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTimeOffset DeletedTime { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
    }
}
