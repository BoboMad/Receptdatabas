using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Receptdatabas.Repositories.Models.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Value { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
