using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Infrastructure.Context;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

   public DbSet<User> Users { get; set; }
   //public DbSet<Product> Products { get; set; }
   // public DbSet<Order> Orders { get; set; }
   // public DbSet<OrderLine> OrderLines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Property(p=> p.FullName)
            .HasConversion(name=>name.Value, value => new Name(value));

        modelBuilder.Entity<User>().Property(p => p.Email)
           .HasConversion(email => email.Value, value => new Email(value));

        modelBuilder.Entity<User>().Property(p => p.Password)
           .HasConversion(password => password.Value, value => new Password(value));

        modelBuilder.Entity<User>().Property(p => p.EmailConfirmCode)
           .HasConversion(emailConfirmCode => emailConfirmCode.Value, value => new EmailConfirmCode(value));

        modelBuilder.Entity<User>().OwnsOne(p => p.Address, addressBuilder =>
        {
            addressBuilder.Property(p=> p.Country).HasColumnType("varchar(50)");
        });
    }
}
