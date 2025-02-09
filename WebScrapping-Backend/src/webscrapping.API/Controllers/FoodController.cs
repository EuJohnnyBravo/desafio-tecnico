using Microsoft.AspNetCore.Mvc;
using WebScrapping.Application.UseCases.Foods.GetAll;
using WebScrapping.Application.UseCases.Foods.GetByCode;
using WebScrapping.Application.UseCases.Foods.Scrap;
using WebScrapping.Communication.Responses;

namespace WebScrapping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> ScrapFoods(
        [FromServices] IScrapFoodsUseCase useCase)
    {
        await useCase.Execute();
        return Created(string.Empty, null);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetAllFoodJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllFoodsUseCase useCase)
    {
        var response = await useCase.Execute();
        return Ok(response);
    }

    [HttpGet()]
    [Route("code/{code}")]
    [ProducesResponseType(typeof(ResponseSingleFoodJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByCode(
        [FromServices] IGetFoodByCodeUseCase useCase,
        string code)
    {
        var response = await useCase.Execute(code);
        if (response == null)
        {
            return NotFound(new ResponseErrorsJson("Food not found"));
        }
        return Ok(response);
    }

}
