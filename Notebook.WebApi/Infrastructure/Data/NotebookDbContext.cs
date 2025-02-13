using Microsoft.EntityFrameworkCore;
using Notebook.WebApi.Infrastructure.Data.Entities;

namespace Notebook.WebApi.Infrastructure.Data;

public class NotebookDbContext : DbContext
{
    public DbSet<Note> Notes { get; set; }
    public DbSet<NoteCategory> NoteCategories { get; set; }

    public NotebookDbContext(DbContextOptions<NotebookDbContext> options)
        : base(options)
    {

    }
}
