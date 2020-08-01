using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.RazorPages.Data;

namespace ToDo.RazorPages.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private TodoDbContext _dbContext;

        public CreateModel(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Todo Todo { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            _dbContext.Todos.Add(Todo);
            _dbContext.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}

