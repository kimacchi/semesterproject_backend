using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class todo
    {
        public int todoId { get; set; }
        public int userId { get; set; }
        public string list { get; set; }
        public int projectId { get; set; }
    }
}
