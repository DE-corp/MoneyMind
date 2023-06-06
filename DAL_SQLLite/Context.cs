using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SQLLite
{
    public class Costs : DbContext
    {
        public DbSet<Spend> Spends { get; set; }
        public DbSet<Category> Categories { get; set; }

        public Costs()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=CostsDB.db");
        }
    }
}
