namespace Notebook.WebApi.Infrastructure.Data.Entities;

public class NoteCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Note> Notes { get; set; }
}
