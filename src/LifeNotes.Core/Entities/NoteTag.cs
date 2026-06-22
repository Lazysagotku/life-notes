namespace LifeNotes.Core.Entities;

public class NoteTag
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid NoteId { get; set; }
    public FreeNote Note { get; set; } = null!;
    public required string Value { get; set; }
}
