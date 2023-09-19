using Infrastructure.Model.Interfaces;

namespace Infrastructure.Model.Implementations
{
    public class Entity<TEntityId> : IEntityTimestamps
    {
        public TEntityId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Entity()
        {
            Id = default;
        }

        public Entity(TEntityId id)
        {
            Id = id;
        }
    }
}
