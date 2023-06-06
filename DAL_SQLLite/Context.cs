﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_SQLLite
{
    public class CostsDbContext : DbContext
    {
        public DbSet<Spend> Spends{get; set;}
        public DbSet<Category> Categories { get; set; }

        public CostsDbContext()
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=CostsDB.db");
        }
    }
}
