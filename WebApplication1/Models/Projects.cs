using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Projects
    {
        public int projectId { get; set; }
        public int userId { get; set; }
        public string projectName { get; set; }
        public string todoList { get; set; }

    }
}
