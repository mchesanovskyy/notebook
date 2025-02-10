namespace Notebook.WebApi.Data.Entities;

public class Note
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Tags { get; set; }
    public int? NoteCategoryId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdatedAt { get; set; }

    public virtual NoteCategory NoteCategory { get; set; }
}

public class NoteCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Note> Notes { get; set; }
}
