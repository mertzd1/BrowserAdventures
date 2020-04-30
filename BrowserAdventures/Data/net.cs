using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BrowserAdventures.Models;

namespace browsersqlserver.database.windows
{
    public class net : DbContext
    {
        public net (DbContextOptions<net> options)
            : base(options)
        {
        }

        public DbSet<BrowserAdventures.Models.AccessPoint> AccessPoint { get; set; }

        public DbSet<BrowserAdventures.Models.User> User { get; set; }
    }
}
