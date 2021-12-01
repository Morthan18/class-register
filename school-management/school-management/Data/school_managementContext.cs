using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using school_management.Models;

namespace school_management.Data
{
    public class school_managementContext : DbContext
    {
        public school_managementContext (DbContextOptions<school_managementContext> options)
            : base(options)
        {
        }

        public DbSet<school_management.Models.Student> Student { get; set; }
    }
}
