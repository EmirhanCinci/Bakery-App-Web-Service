using Infrastructure.Model.Interfaces;

namespace Infrastructure.Model.Implementations
{
    public class Dto<TDtoId> : IDto
    {
        public TDtoId Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Dto()
        {
            Id = default;
        }

        public Dto(TDtoId id)
        {
            Id = id;
        }
    }
}
