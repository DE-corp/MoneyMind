using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SQLLite.Models
{
    public class Spend
    {
        public int SpendId { get; set; }
        public decimal Cost { get; set; }

        public Category Category { get; set; }
    }
}
