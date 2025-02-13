using MediatR;
using Notebook.WebApi.Models;

namespace Notebook.WebApi.Infrastructure.Requests;

public class CreateNoteCategoryRequest : IRequest<NoteCategoryModelOut>
{
    public CreateNoteCategoryRequest(NoteCategoryModelIn model)
    {
        Model = model;
    }

    public NoteCategoryModelIn Model { get; }
}
