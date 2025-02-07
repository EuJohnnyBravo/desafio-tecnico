using Microsoft.AspNetCore.Mvc;
using WebScrapping.Application.UseCases.Food.Search;
using WebScrapping.Communication.Requests;

namespace WebScrapping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SearchFood(
        [FromServices] ISearchFoodUseCase useCase,
        [FromBody] RequestSearchFoodJson request)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
}
