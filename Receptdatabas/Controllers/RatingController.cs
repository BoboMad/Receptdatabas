using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Receptdatabas.Repositories.Models.Entities;
using Receptdatabas.Services.Interfaces;

namespace Receptdatabas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost]
        [Route("/api/Rating")]
        public IActionResult CreateRating(Rating rating)
        {
            try
            {
                _ratingService.CreateRating(rating);
                return Ok("Rating created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
