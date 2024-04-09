using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Receptdatabas.Repositories.Models.Entities;
using Receptdatabas.Services.Interfaces;

namespace Receptdatabas.Controllers
{
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        [Route("/api/[controller]/AllRecipes")]
        public IActionResult GetAllRecipes()
        {
            var recipesDto =  _recipeService.GetAllRecipes();
            return Ok(recipesDto);
        }

        [HttpGet]
        [Route("/api/[controller]/{searchParam}")]
        public IActionResult SearchRecipe(string searchParam) 
        {
            try
            {
               var results = _recipeService.SearchRecipe(searchParam);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("/api/[controller]")]
        public IActionResult CreateRecipe(Recipe recipe)
        {
            try
            {
                _recipeService.CreateRecipe(recipe);
                return Ok("Recipe created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("/api/[controller]/{id}")]
        public IActionResult UpdateRecipe(int id, [FromBody] Recipe recipe)
        {
            try
            {
                _recipeService.UpdateRecipe(id, recipe);
                return Ok("Recipe updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/api/[controller]/{id}")]
        public IActionResult DeleteRecipe(int id, [FromHeader]int userId)
        {
            try
            {
                _recipeService.DeleteRecipe(id, userId);
                return Ok("Recipe Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
