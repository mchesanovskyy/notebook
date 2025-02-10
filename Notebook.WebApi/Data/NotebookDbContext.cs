using Microsoft.EntityFrameworkCore;
using Notebook.WebApi.Data.Entities;

namespace Notebook.WebApi.Data;

public class NotebookDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteCategory> NoteCategories { get; set; }

    public NotebookDbContext(DbContextOptions<NotebookDbContext> options)
        : base(options)
    {

    }
}
