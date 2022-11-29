using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaliacaoD7.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoD7.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    Email = "admin@email.com",
                    Password = "admin123",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Gabriel Di Vanna Camargo",
                    Email = "gabriel@email.com",
                    Password = "Gabriel123",

                });

            entity.HasKey(u => u.Email);
            entity.HasIndex(u => u.Id).IsUnique();
        });
        base.OnModelCreating(modelBuilder);
    }
}
