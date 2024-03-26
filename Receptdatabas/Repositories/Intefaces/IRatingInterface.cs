using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Intefaces
{
    public interface IRatingInterface
    {
        void CreateRating(Rating rating);
        Rating GetRating(int id);
        IEnumerable<Rating> GetRatingsForRecipe(int recipeId);
        Rating UpdateRating(Rating rating);
        void DeleteRating(int id);

    }
}
