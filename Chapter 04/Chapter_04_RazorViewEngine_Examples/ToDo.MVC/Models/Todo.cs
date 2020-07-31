using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.MVC.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public bool IsComplete { get; set; }
    }
}
