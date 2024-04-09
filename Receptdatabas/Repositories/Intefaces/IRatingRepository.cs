using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Intefaces
{
    public interface IRatingRepository
    {
        void CreateRating(Rating rating);
        Rating GetRating(int id);
        Rating GetRatingByUserAndRecipe(int userId, int recipeId);

        IEnumerable<Rating> GetRatingsForRecipe(int recipeId);
        Rating UpdateRating(Rating rating);
        void DeleteRating(int id);

    }
}
