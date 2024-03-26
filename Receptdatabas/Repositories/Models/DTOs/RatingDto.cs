using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Models.DTOs
{
    public class RatingDto
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public virtual Recipe Recipe { get; set; }

        public virtual User User { get; set; }
    }
}
