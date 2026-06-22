using LifeNotes.Core.Entities;

namespace LifeNotes.Core.Interfaces;

public interface INoteRepository
{
    Task<Note?> GetByIdAsync(Guid id, Guid userId);
    Task<IReadOnlyList<Note>> GetAllAsync(Guid userId);
    Task AddAsync(Note note);
    void Update(Note note);
    void Delete(Note note);
}
