namespace LifeNotes.Core.Entities;

public class MusicNote : Note
{
    public required string Artist { get; set; }
    public string? Album { get; set; }
    public string? Track { get; set; }
    public string? MoodAtMoment { get; set; }
    public string? Thoughts { get; set; }
    public string? WhatInfluencedThoughts { get; set; }
    public string? WhoToShareWith { get; set; }
}
