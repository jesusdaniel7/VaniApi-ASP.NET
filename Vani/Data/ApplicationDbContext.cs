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
            :base(options)
        {

        }

        DbSet<StoreType> StoreTypes { get; set; }
        DbSet<Store> Stores { get; set; }
    }
}
