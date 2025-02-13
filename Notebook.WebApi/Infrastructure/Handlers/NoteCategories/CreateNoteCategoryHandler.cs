using MediatR;
using Notebook.WebApi.Infrastructure.Data;
using Notebook.WebApi.Infrastructure.Extensions;
using Notebook.WebApi.Infrastructure.Requests;
using Notebook.WebApi.Models;

namespace Notebook.WebApi.Infrastructure.Handlers.NoteCategories;

public class CreateNoteCategoryHandler : IRequestHandler<CreateNoteCategoryRequest, NoteCategoryModelOut>
{
    private readonly NotebookDbContext _context;

    public CreateNoteCategoryHandler(NotebookDbContext context)
    {
        _context = context;
    }

    public async Task<NoteCategoryModelOut> Handle(CreateNoteCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var noteCategory = request.Model.Transform();
        
        //if (noteCategory == null)
        //{
        //    throw new EntityNotFoundException(nameof(NoteCategory), "Sorry, this category can't be created");
        //}

        _context.NoteCategories.Add(noteCategory);
        await _context.SaveChangesAsync();

        return noteCategory.Transform();
    }
}
