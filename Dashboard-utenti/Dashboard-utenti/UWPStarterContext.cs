using Dashboard_utenti.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard_utenti
{
    public class UWPStarterContext : DbContext
    {
        public DbSet<Anagrafica> Anagrafiche { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = UWP.Starter.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anagrafica>().ToTable("anagrafiche");
        }

    }
}
