using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Expenses
    {
        public int expenseId { get; set; }
        public int userId { get; set; }
        public int amount { get; set; }
        public long createdAt { get; set; }
        public string description { get; set; }
        public string note { get; set; }

    }
}
