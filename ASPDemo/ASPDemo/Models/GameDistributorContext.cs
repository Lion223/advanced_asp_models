using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPDemo.Models
{
    public class GameDistributorContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
    }
}