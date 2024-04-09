using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Receptdatabas.Repositories.Models.Entities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        
        [StringLength(300)]
        public string Description { get; set; }

        [StringLength(200)]
        public string Ingredients { get; set; }

        
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }


        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Rating>? Ratings { get; set; }
    }
}
