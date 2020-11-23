using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Muntean_Oana_Lab8.Models;

namespace Muntean_Oana_Lab8.Data
{
    public class Muntean_Oana_Lab8Context : DbContext
    {
        public Muntean_Oana_Lab8Context (DbContextOptions<Muntean_Oana_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Muntean_Oana_Lab8.Models.Book> Book { get; set; }

        public DbSet<Muntean_Oana_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Muntean_Oana_Lab8.Models.Category> Category { get; set; }
    }
}
