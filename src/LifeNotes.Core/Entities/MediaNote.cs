using LifeNotes.Core.Enums;

namespace LifeNotes.Core.Entities;

public class MediaNote : Note
{
    public required string Title { get; set; }
    public MediaType MediaType { get; set; }
    public MediaStatus Status { get; set; }
    public int? CurrentSeason { get; set; }
    public int? CurrentEpisode { get; set; }
    public string? ResourceUrl { get; set; }
    public string? Impressions { get; set; }
}
