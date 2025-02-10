namespace Notebook.WebApi.Models;

public class NoteModel
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}

public class NoteCategoryModelIn
{
    public string Name { get; set; }

    public NoteCategoryModelIn Clone()
    {
        return new NoteCategoryModelIn()
        {
            Name = Name
        };
    }
}

public class NoteCategoryModelOut
{
    public int Id { get; set; }
    public string Name { get; set; }
}
