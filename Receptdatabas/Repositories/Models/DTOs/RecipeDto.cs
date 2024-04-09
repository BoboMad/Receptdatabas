using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Models.DTOs
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
        public UserDto Creator { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }
}
