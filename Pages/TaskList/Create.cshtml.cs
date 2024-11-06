using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoApplication.DAL;
using ToDoApplication.Models;

namespace ToDoApplication.Pages.TaskList
{
    public class CreateModel : PageModel
    {
        private readonly ToDoApplication.DAL.AppDbContext _context;

        public CreateModel(ToDoApplication.DAL.AppDbContext context)
        {
            _context = context;

            AssigntoOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "Santhush", Text = "Santhush" },
            new SelectListItem { Value = "Dinuwara", Text = "Dinuwara" },
            new SelectListItem { Value = "Devin", Text = "Devin" }
        };
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ToDoItem ToDoItem { get; set; } = default!;
        public List<SelectListItem> AssigntoOptions { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ToDoItems.Add(ToDoItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
