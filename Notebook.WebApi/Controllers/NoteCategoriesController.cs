using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notebook.WebApi.Infrastructure.Data;
using Notebook.WebApi.Infrastructure.Extensions;
using Notebook.WebApi.Infrastructure.Requests;
using Notebook.WebApi.Models;

namespace Notebook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteCategoriesController : ControllerBase
    {
        private readonly NotebookDbContext _context;
        private readonly IMediator mediator;

        public NoteCategoriesController(NotebookDbContext context,
            IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<NoteCategoryModelOut>> GetNoteCategories()
        {
            var categories =  await _context.NoteCategories
                .ToListAsync();
            return categories.Transform();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteCategoryModelOut>> GetNoteCategory(int id)
        {
            var noteCategory = await _context.NoteCategories.FindAsync(id);

            if (noteCategory == null)
            {
                return NotFound();
            }

            return noteCategory.Transform();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoteCategory(int id, NoteCategoryModelIn noteCategoryModel)
        {

            try
            {
                var noteCategory = await _context.NoteCategories.FindAsync(id);
                noteCategory.Name = noteCategory.Name;
                _context.Update(noteCategory);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public Task<NoteCategoryModelOut> PostNoteCategory(NoteCategoryModelIn noteCategoryModel)
        {
            return mediator.Send(new CreateNoteCategoryRequest(noteCategoryModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteCategory(int id)
        {
            var noteCategory = await _context.NoteCategories.FindAsync(id);
            if (noteCategory == null)
            {
                return NotFound();
            }

            _context.NoteCategories.Remove(noteCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteCategoryExists(int id)
        {
            return _context.NoteCategories.Any(e => e.Id == id);
        }
    }
}
