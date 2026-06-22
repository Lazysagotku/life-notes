namespace LifeNotes.Core.Entities;

public class FreeNote : Note
{
    public required string Title { get; set; }
    public required string Text { get; set; }
    public ICollection<NoteTag> Tags { get; set; } = [];
}
