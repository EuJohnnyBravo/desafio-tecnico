﻿using Microsoft.AspNetCore.Mvc;
using WebScrapping.Application.UseCases.Food.Scrap;
using WebScrapping.Communication.Requests;

namespace WebScrapping.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FoodController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SearchFood(
        [FromServices] ISearchFoodUseCase useCase)
    {
        var response = await useCase.Execute();
        return Created(string.Empty, response);
    }
}
