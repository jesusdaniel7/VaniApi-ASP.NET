using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vani.Models;

namespace Vani.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<StoreType> StoreTypes { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<StorePhotos> StorePhotos { get; set; }
    }
}
