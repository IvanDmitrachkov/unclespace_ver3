using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace unclespace_ver3.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }


    public class Product
    {
        public int Id { get; set; }

        [Display(Name ="Название")]
        public string Name { get; set; }

        [Display(Name = "Заглавие")]
        public string Title { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
        public string ImagePath { get; set; }

        [Display(Name = "Особенности")]
        public string Features { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }


        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public ICollection<Product> Products { get; set; }
        public Category()
        {
            Products = new List<Product>();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}