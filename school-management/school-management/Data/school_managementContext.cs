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

        public DbSet<school_management.Models.Class> Class { get; set; }

        public DbSet<school_management.Models.Grade> Grade { get; set; }

        public DbSet<school_management.Models.Parent> Parent { get; set; }

        public DbSet<school_management.Models.SchoolSubject> SchoolSubject { get; set; }

        public DbSet<school_management.Models.Teacher> Teacher { get; set; }

        public DbSet<school_management.Models.News> News { get; set; }
    }
}
