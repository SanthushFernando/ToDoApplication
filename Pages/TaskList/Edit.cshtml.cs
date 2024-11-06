using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.DAL;
using ToDoApplication.Models;

namespace ToDoApplication.Pages.TaskList
{
    public class EditModel : PageModel
    {
        private readonly ToDoApplication.DAL.AppDbContext _context;

        public EditModel(ToDoApplication.DAL.AppDbContext context)
        {
            _context = context;

            AssigntoOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Santhush", Text = "Santhush" },
                new SelectListItem { Value = "Dinuwara", Text = "Dinuwara" },
                new SelectListItem { Value = "Devin", Text = "Devin" }
            };
        }

        [BindProperty]
        public ToDoItem ToDoItem { get; set; } = default!;

        public List<SelectListItem> AssigntoOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoitem =  await _context.ToDoItems.FirstOrDefaultAsync(m => m.Id == id);
            if (todoitem == null)
            {
                return NotFound();
            }
            ToDoItem = todoitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ToDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(ToDoItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ToDoItemExists(int id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }
    }
}
