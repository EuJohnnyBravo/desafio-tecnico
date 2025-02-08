﻿using WebScrapping.Communication.Responses;

namespace WebScrapping.Application.UseCases.Food.GetAll;

public interface IGetAllFoodsUseCase
{
    Task<ResponseFoodsJson> Execute();
}
