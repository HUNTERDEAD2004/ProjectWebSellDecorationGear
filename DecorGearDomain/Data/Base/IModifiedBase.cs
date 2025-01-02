namespace DecorGearDomain.Data.Base
{
    public interface IModifiedBase
    {
        public DateTimeOffset ModifiedTime { get; set; }

        public int? ModifiedBy { get; set; }

    }
}
