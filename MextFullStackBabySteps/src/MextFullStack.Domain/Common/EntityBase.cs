namespace MextFullStack.Domain.Common
{
    public abstract class EntityBase<TKey>
    {
        public TKey Id { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual string CreatedByUserId { get; set; } 
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedByUserId { get; set; }
    }
}