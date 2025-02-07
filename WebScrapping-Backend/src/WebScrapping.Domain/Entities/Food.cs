namespace WebScrapping.Domain.Entities;
public class Food
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? ScientificName { get; set; }
    public string Group { get; set; } = string.Empty;
    public ICollection<FoodComposition> Compositions { get; set; } = new List<FoodComposition>();
}
