using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TodoCore.Models;

namespace TodoCore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TodoItem>()
                .HasMany(t => t.Steps)
                .WithOne(s => s.Todo);

            builder.Entity<TodoItem>().HasKey(t => t.Id);
            builder.Entity<TodoStep>().HasKey(s => s.Id);
        }

        public DbSet<TodoItem> Items { get; set; }
        public DbSet<TodoStep> TodoSteps { get; set; }
    }
}
