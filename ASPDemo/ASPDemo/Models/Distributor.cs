using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDemo.Models
{
    public class Distributor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }

        public ICollection<Game> Games { get; set; }
        
        public Distributor()
        {
            Games = new List<Game>();
        }
    }
}