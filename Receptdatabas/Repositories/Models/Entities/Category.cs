using System.ComponentModel.DataAnnotations;

namespace Receptdatabas.Repositories.Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
