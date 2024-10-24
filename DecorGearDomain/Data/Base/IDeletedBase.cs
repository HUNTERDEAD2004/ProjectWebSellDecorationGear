
namespace DecorGearDomain.Data.Base
{
    public interface IDeletedBase
    {
        public bool Deleted { get; set; }

        public Guid? DeletedBy { get; set; }

        public DateTimeOffset DeletedTime { get; set; }

    }
}
