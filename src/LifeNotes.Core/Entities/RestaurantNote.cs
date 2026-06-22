namespace LifeNotes.Core.Entities;

public class RestaurantNote : Note
{
    public required string Name { get; set; }
    public required string Address { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? GeneralImpression { get; set; }
    public int Rating { get; set; } // 1-10
    public ICollection<RestaurantDish> Dishes { get; set; } = [];
}
