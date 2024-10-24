using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bai_ThucHanh.Models;

namespace Bai_ThucHanh.Data
{
    public class Bai_ThucHanhContext : DbContext
    {
        public Bai_ThucHanhContext (DbContextOptions<Bai_ThucHanhContext> options)
            : base(options)
        {
        }

        public DbSet<Bai_ThucHanh.Models.Category> Category { get; set; } = default!;

        public DbSet<Bai_ThucHanh.Models.Productcs> Productcs { get; set; } = default!;

        public DbSet<Bai_ThucHanh.Models.User> User { get; set; } = default!;
    }
}
