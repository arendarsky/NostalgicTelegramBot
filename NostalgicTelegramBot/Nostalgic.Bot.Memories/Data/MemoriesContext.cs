using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Nostalgic.Bot.Memories.Entities;

namespace Nostalgic.Bot.Memories.Data
{
    internal sealed class MemoriesContext: DbContext
    {
        public MemoriesContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Memory> Memories { get; set; }
        public DbSet<Content> Contents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./Memories.sqlite");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
