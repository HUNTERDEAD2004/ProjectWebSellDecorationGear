namespace DecorGearDomain.Data.Base
{
    public interface IDeletedBase
    {
        public bool Deleted { get; set; }

        public int? DeletedBy { get; set; }

        public DateTimeOffset DeletedTime { get; set; }

    }
}
