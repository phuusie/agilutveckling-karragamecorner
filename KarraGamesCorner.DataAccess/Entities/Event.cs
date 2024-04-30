using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarraGameCorner.DataAccess.Entities
{
    public class Event
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public DateTime Date { get; set; }
    }
}
