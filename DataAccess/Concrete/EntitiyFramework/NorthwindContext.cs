using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{   //context: Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext: DbContext
    {
        //proje hangi veritabanıyla ilgişkili onu belrten metot
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   //@ ekleme sebebimiz /  işaretini doğru anlamaısnı sağlamak
            //normalde "" içinde yazsak bile bir anlamı oluyor // kullanırsak anlamı normale dönüyor bunu yapmamak için @ koyduk
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=master;Trusted_Connection=true");
        }
        //product nesnemi db deki product ile bağla
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
