namespace DecorGearDomain.Data.Base
{
    public interface ICreatedBase
    {
        public DateTimeOffset CreatedTime { get; set; }

        public int? CreatedBy { get; set; }
    }
}
