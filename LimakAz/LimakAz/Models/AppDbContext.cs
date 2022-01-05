using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }


        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ShopItem> ShopItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Privacy> Privacies { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<WareHouse> WareHouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Courier> Couriers { get; set; }
    }
}
