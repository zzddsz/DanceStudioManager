namespace DanceStudio.Domain.Base
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
    }
}