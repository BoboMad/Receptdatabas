using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Models.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Recipe> Recipes { get; set; }

    }
}
