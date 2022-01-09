using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTAPISMART.Data
{
    public class ApiDBContext : DbContext
    {

        public ApiDBContext(DbContextOptions<ApiDBContext> options)
        : base(options)
        {

        }

        public DbSet<Properties> Properties { get; set; }
        public DbSet<Management> Managements { get; set; }

    }
}
