
namespace DecorGearDomain.Data.Base
{
    public interface ICreatedBase
    {
        public DateTimeOffset CreatedTime { get; set; }

        public Guid? CreatedBy { get; set; }
    }
}
