using AutoMapper;
using Receptdatabas.Repositories.Implementations;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.DTOs;
using Receptdatabas.Repositories.Models.Entities;
using Receptdatabas.Services.Interfaces;

namespace Receptdatabas.Services.Implementations
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public RecipeService(IRecipeRepository recipeRepository,ICategoryRepository categoryRepository ,IMapper mapper)
        {
            _recipeRepository = recipeRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public void CreateRecipe(Recipe recipe)
        {
            if (recipe == null) throw new ArgumentNullException("Invalid recipe");
            if (recipe.UserId <= 0 || recipe.UserId == null) throw new ArgumentException("Login to create recipes");
            else _recipeRepository.CreateRecipe(recipe);

        }

        public void DeleteRecipe(int id, int userId)
        {
            var recipeToDelete = _recipeRepository.GetRecipe(id);

            if(recipeToDelete.User.Id == userId)
            {
                _recipeRepository.DeleteRecipe(id);
            }
            else
            {
                throw new ArgumentException("Only the creator can delete this recipe");
            }
            
        }

        public IEnumerable<RecipeDto> GetAllRecipes()
        {
            var recipes = _recipeRepository.GetAllRecipes();
            if (recipes == null || !recipes.Any())
            {
                throw new ArgumentNullException("No recipes found");
            }

            return _mapper.Map<List<RecipeDto>>(recipes);
        }

        public IEnumerable<RecipeDto> SearchRecipe(string searchParam)
        {
            var searchResult = _recipeRepository.SearchRecipe(searchParam);
            
            if(searchResult == null)
            {
                throw new ArgumentNullException("No recipes found");
            }
            return _mapper.Map<IEnumerable<RecipeDto>>(searchResult);
        }


        public RecipeDto GetRecipe(int id)
        {
            throw new NotImplementedException();
        }

        public RecipeDto UpdateRecipe(int id, Recipe recipe)
        {
            if (recipe != null)
            {
                recipe.Id = id;
                _recipeRepository.UpdateRecipe(recipe);
                return _mapper.Map<RecipeDto>(recipe);
            }
            else
            {
                throw new ArgumentNullException("User was null");
            }
        }
    }
}
