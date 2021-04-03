using Hahn.ApplicationProcess.February2021.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Data.Context
{
    public class HahnDataContext : DbContext 
    {
        public DbSet<Asset> Assets { get; set; }
        public HahnDataContext(DbContextOptions options)
        : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            
        }

    }
}
