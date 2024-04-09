using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Receptdatabas.Repositories.Contexts;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.Entities;

namespace Receptdatabas.Repositories.Implementations
{
    public class RecipeRepository:IRecipeRepository
    {
        private readonly MyDbContext _context;
        public RecipeRepository(MyDbContext context)
        {
            _context = context;
        }

        public void CreateRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            var recipeToDelete = _context.Recipes.Find(id);
            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.User)
                .ToList();
        }

        public Recipe GetRecipe(int id)
        {
            return _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.User)
                .SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Recipe> SearchRecipe(string searchParam)
        {
            return _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.User)
                .ToList()
                .Where(r => r.Title.Contains(searchParam));
        }


        public void UpdateRecipe(Recipe recipe)
        {
            _context.Entry(recipe).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
