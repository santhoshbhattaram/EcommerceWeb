using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using EcommerceModels.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceData.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
                
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 2 },
                new Category { Id = 2, Name = "Drama", DisplayOrder = 1 },
                new Category { Id = 3, Name = "Horror", DisplayOrder = 3 }
            ); 
        }


    }
}
