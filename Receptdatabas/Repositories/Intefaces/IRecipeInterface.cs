using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Intefaces
{
    public interface IRecipeInterface
    {
        void CreateRecipe(Recipe recipe);
        Recipe GetRecipe(int id);
        IEnumerable<Recipe> GetAllRecipes();
        void UpdateRecipe(Recipe recipe);
        void DeleteRecipe(int id);
    }
}
