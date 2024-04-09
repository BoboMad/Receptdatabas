using Receptdatabas.Repositories.Contexts;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Implementations
{
    public class RatingRepository : IRatingRepository
    {
        private readonly MyDbContext _context;

        public RatingRepository(MyDbContext context)
        {
            _context = context;
        }
        public void CreateRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
        }
        public Rating GetRatingByUserAndRecipe(int userId, int recipeId)
        {
            return _context.Ratings.FirstOrDefault(r => r.UserID == userId && r.RecipeId == recipeId);
        }

        public void DeleteRating(int id)
        {
            throw new NotImplementedException();
        }

        public Rating GetRating(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rating> GetRatingsForRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Rating UpdateRating(Rating rating)
        {
            throw new NotImplementedException();
        }
    }
}
