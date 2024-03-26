using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Receptdatabas.Repositories.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Username { get; set; }

        [StringLength(50)]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
    }
}
