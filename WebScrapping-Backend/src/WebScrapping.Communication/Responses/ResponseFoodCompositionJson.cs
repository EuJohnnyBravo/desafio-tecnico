using WebScrapping.Domain.Entities;

namespace WebScrapping.Communication.Responses;

public class ResponseFoodCompositionJson
{
    public string FoodCode { get; set; } = string.Empty;
    public string Component { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public decimal? ValuePer100g { get; set; }
    public decimal? StandardDeviation { get; set; }
    public decimal? MinimumValue { get; set; }
    public decimal? MaximumValue { get; set; }
    public int? NumberOfDataUsed { get; set; }
    public string? Reference { get; set; }
    public string? DataType { get; set; }
}
