using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFinal.Service.Models;

namespace WebFinal.Service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options) 
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Giyim> Giyimler { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Taki> Takiler { get; set;}



    }
}
