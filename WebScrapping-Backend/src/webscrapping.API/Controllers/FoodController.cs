using Microsoft.AspNetCore.Mvc;
using WebScrapping.Application.UseCases.Foods.GetAll;
using WebScrapping.Application.UseCases.Foods.Scrap;
using WebScrapping.Communication.Responses;

namespace WebScrapping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterFoodsJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> SearchFood(
        [FromServices] IScrapFoodsUseCase useCase)
    {
        var response = await useCase.Execute();
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseFoodsJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll(
        [FromServices] IGetAllFoodsUseCase useCase)
    {
        var response = await useCase.Execute();
        return Ok(response);
    }

}
