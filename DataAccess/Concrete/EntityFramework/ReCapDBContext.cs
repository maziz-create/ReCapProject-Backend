using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // bu class DB tabloları ile proje classlarını bağlayacak
    public class ReCapDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);bunu sildik.

            //optionsBuilder.UseSqlServer(@"Server=175.45.2.12"); normal bi projede bu şekilde yapılır. sql serverin nerede olduğu anlatılır.

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReCapDB;Trusted_Connection=true");
            //trusted kısmı kullanıcı adı şifre gerektirmeden girmeye yarıyor. geri kalan tamamen db ' nin nerede olduğuna dair.
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
    }
}
