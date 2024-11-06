using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoApplication.DAL;
using ToDoApplication.Models;

namespace ToDoApplication.Pages.TaskList
{
    public class DetailsModel : PageModel
    {
        private readonly ToDoApplication.DAL.AppDbContext _context;

        public DetailsModel(ToDoApplication.DAL.AppDbContext context)
        {
            _context = context;
        }

        public ToDoItem ToDoItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoitem = await _context.ToDoItems.FirstOrDefaultAsync(m => m.Id == id);
            if (todoitem == null)
            {
                return NotFound();
            }
            else
            {
                ToDoItem = todoitem;
            }
            return Page();
        }
    }
}
