using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Intefaces
{
    public interface IRecipeRepository
    {
        void CreateRecipe(Recipe recipe);
        Recipe GetRecipe(int id);
        IEnumerable<Recipe> SearchRecipe(string searchParam);
        IEnumerable<Recipe> GetAllRecipes();
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int id);
    }
}
