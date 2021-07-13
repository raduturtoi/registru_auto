using Microsoft.EntityFrameworkCore;
using registru_auto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace registru_auto.Contexts
{
    public class CarsContexts : DbContext
    {
        public CarsContexts(DbContextOptions<CarsContexts> options) 
          : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Owners> Owners { get; set; }
        public DbSet<Cars> Cars { get; set; }

    } 
}
