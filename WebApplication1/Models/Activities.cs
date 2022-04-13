using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Activities
    {
        public int activityId { get; set; }
        public string activityName { get; set; }
        public int userId { get; set; }
        public string description { get; set; }
        public string activityTime { get; set; }
    }
}
