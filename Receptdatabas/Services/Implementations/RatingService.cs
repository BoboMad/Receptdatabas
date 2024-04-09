using Microsoft.AspNetCore.Http.HttpResults;
using Receptdatabas.Repositories.Intefaces;
using Receptdatabas.Repositories.Models.Entities;
using Receptdatabas.Services.Interfaces;

namespace Receptdatabas.Services.Implementations
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRecipeRepository _recipeRepository;
        public RatingService(IRatingRepository ratingRepository, IRecipeRepository recipeRepository, IUserRepository userRepository)
        {
            _ratingRepository = ratingRepository;
            _userRepository = userRepository;
            _recipeRepository = recipeRepository;
        }
        public void CreateRating(Rating rating)
        {
            var user = _userRepository.GetUserById(rating.UserID);
            var recipe = _recipeRepository.GetRecipe(rating.RecipeId);


            if(recipe == null || user == null || recipe.User.Id == user.Id) 
            {
                throw new ArgumentException("Invalid rating details");
            }

            var exsitingRating = _ratingRepository.GetRatingByUserAndRecipe(user.Id, recipe.Id);
            if(exsitingRating != null)
            {
                throw new ArgumentException("Already rated by user");
            }

            rating.User = user;
            rating.Recipe = recipe;

            _ratingRepository.CreateRating(rating);
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
