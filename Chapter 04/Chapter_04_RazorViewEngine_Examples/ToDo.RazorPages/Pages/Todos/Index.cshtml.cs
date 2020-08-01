using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.RazorPages.Data;

namespace ToDo.RazorPages.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private TodoDbContext _dbContext;

        public IndexModel(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Todo> Todos { get; set; }

        public void OnGet()
        {
            Todos = _dbContext.Todos.ToList();
        }
    }
}

