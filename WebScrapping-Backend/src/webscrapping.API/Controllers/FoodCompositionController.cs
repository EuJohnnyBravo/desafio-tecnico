using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebScrapping.Application.UseCases.FoodComposition.RegisterByCode;

namespace WebScrapping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCompositionController : ControllerBase
    {
        [HttpPost]
        [Route("code")]
        public Task<IActionResult> RegisterFoodComposition(
            [FromServices] IRegisterFoodCompositionByCodeUseCase useCase,
            [FromRoute] string code)
        {
            return Task.FromResult<IActionResult>(Ok());
        }
    }
}
