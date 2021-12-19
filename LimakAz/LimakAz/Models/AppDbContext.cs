using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimakAz.Models
{
    public class AppDbContext:DbContext
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
    }
}
