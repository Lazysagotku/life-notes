namespace LifeNotes.Core.Entities;

public class RestaurantDish
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid NoteId { get; set; }
    public RestaurantNote Note { get; set; } = null!;
    public required string Name { get; set; }
    public string? Impression { get; set; }
    public int Rating { get; set; } // 1-5
}
