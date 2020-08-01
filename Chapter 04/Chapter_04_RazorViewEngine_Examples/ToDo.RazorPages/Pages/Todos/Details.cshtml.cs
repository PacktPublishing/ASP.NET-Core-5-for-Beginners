using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.RazorPages.Data;

namespace ToDo.RazorPages.Pages.Todos
{
    public class DetailsModel : PageModel
    {
        private TodoDbContext _dbContext;

        public DetailsModel(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Todo Todo { get; set; }
        public void OnGet(int id)
        {
            Todo = _dbContext.Todos.Find(id);
        }
    }
}