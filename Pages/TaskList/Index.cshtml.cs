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
    public class IndexModel : PageModel
    {
        private readonly ToDoApplication.DAL.AppDbContext _context;

        public IndexModel(ToDoApplication.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<ToDoItem> ToDoItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            ToDoItem = await _context.ToDoItems.ToListAsync();
        }
    }
}
