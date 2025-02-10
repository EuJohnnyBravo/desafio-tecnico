using Microsoft.AspNetCore.Mvc;
using WebScrapping.Application.UseCases.FoodCompositions.GetByCode;
using WebScrapping.Application.UseCases.FoodCompositions.RegisterByCode;
using WebScrapping.Communication.Responses;

namespace WebScrapping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCompositionController : ControllerBase
    {
        [HttpPost]
        [Route("code/{code}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RegisterFoodComposition(
            [FromServices] IRegisterFoodCompositionByCodeUseCase useCase,
            [FromRoute] string code)
        {
            await useCase.Execute(code);
            return Created(string.Empty, null);
        }

        [HttpGet]
        [Route("code/{code}")]
        [ProducesResponseType(typeof(ResponseGetAllFoodCompositionByCodeJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFoodComposition(
            [FromServices] IGetFoodCompositionByCodeUseCase useCase,
            [FromRoute] string code)
        {
            var response = await useCase.Execute(code);
            return Ok(response);
        }
    }
}
