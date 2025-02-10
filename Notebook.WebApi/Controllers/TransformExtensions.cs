using Notebook.WebApi.Data.Entities;
using Notebook.WebApi.Models;

namespace Notebook.WebApi.Controllers;

public static class TransformExtensions
{
    public static NoteCategory Transform(this NoteCategoryModelIn category)
    {
        return new NoteCategory()
        {
            Name = category.Name,
        };
    }

    public static NoteCategoryModelOut Transform(this NoteCategory category)
    {
        return new NoteCategoryModelOut
        {
            Id = category.Id,
            Name = category.Name,
        };
    }

    public static IEnumerable<NoteCategoryModelOut> Transform(this IEnumerable<NoteCategory> categories)
    {
        return categories.Select(c => c.Transform());
    }
}