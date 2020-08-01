using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.RazorPages.Data;

namespace ToDo.RazorPages.Pages.Todos
{
    public class EditModel : PageModel
    {
        private TodoDbContext _dbContext;

        public EditModel(TodoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Todo Todo { get; set; }
        public void OnGet(int id)
        {
            Todo = _dbContext.Todos.Find(id);
        }

        public IActionResult OnPost()
        {
            _dbContext.Todos.Update(Todo);
            _dbContext.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}


public class EditModel : PageModel
{
    private TodoDbContext _dbContext;

    public EditModel(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [BindProperty]
    public Todo Todo { get; set; }
    public void OnGet(int id)
    {
        Todo = _dbContext.Todos.Find(id);
    }

    public IActionResult OnPost()
    {
        _dbContext.Todos.Update(Todo);
        _dbContext.SaveChanges();

        return RedirectToPage("./Index");
    }
}