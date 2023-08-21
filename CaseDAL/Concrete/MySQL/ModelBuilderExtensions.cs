using CaseEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDAL.Concrete.MySQL
{
    public static class ModelBuilderExtensions
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            Guid telephoneId = Guid.NewGuid();
            Guid tabletId = Guid.NewGuid();
            Guid pcId = Guid.NewGuid();

            builder.Entity<Category>().HasData
                (
                new Category() { Id = telephoneId, Name = "Telefon",Description="En kaliteli telefonlar", CreatedOn = DateTime.UtcNow },
                new Category() { Id = tabletId, Name = "Tablet",Description="En kaliteli tabletler" , CreatedOn = DateTime.UtcNow },
                new Category() { Id = pcId, Name = "Bilgisayar",Description="En kaliteli bilgisayarlar" , CreatedOn = DateTime.UtcNow }
                
                
                );

            builder.Entity<Product>().HasData
                (
                new Product { Id = Guid.NewGuid(),CategoryId = telephoneId,Name="Iphone 14 Pro",Description="En sağlam telefon",Quantity = 5,Unit="ADET",CreatedOn=DateTime.UtcNow,ImageUrl="1.jpg",Price=56000},
                new Product { Id = Guid.NewGuid(),CategoryId = telephoneId,Name="Iphone 13 ",Description="Güncel telefon",Quantity = 15,Unit="ADET", CreatedOn = DateTime.UtcNow, ImageUrl = "2.jpg", Price = 46000 },
                new Product { Id = Guid.NewGuid(),CategoryId = tabletId,Name="Galaxy TAB S7",Description="Çocuklar için tablet",Quantity = 3,Unit="ADET", CreatedOn = DateTime.UtcNow, ImageUrl = "3.jpg", Price = 20000 },
                new Product { Id = Guid.NewGuid(),CategoryId = tabletId,Name="Matepad SE",Description="İş tableti",Quantity = 35,Unit="ADET", CreatedOn = DateTime.UtcNow, ImageUrl = "4.jpg", Price = 25000 },
                new Product { Id = Guid.NewGuid(),CategoryId = pcId,Name="Hp Envy",Description="İş bilgisayarı",Quantity = 5,Unit="ADET", CreatedOn = DateTime.UtcNow, ImageUrl = "5.jpg", Price = 66000 },
                new Product { Id = Guid.NewGuid(),CategoryId = pcId, Name="Monster Abra",Description="Oyun bilgisayarı",Quantity = 5,Unit="ADET", CreatedOn = DateTime.UtcNow, ImageUrl = "6.jpg", Price = 36000 }
                
                
                
                );

            builder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), FirstName = "Ali", LastName = "Akçekoce", Email = "aliiakcekoca@gmail.com", Password = "qwerty12-", CreatedOn = DateTime.UtcNow });
        }
    }
}
