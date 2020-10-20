using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorCRUDEntity.Shared.Models;

namespace BlazorCRUDEntity.Server.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().Property(d => d.Experience).HasColumnType("DECIMAL(5,2)");
        }
        public DbSet<Developer> Developers { get; set; }
    }
}
