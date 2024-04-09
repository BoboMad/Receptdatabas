using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Services.Interfaces
{
    public interface IRecipeService
    {
        void CreateRecipe(Recipe recipe);
        RecipeDto GetRecipe(int id);
        IEnumerable<RecipeDto> SearchRecipe(string searchParam);
        IEnumerable<RecipeDto> GetAllRecipes();
        RecipeDto UpdateRecipe(int id, Recipe recipe);
        void DeleteRecipe(int id, int userId);
    }
}
