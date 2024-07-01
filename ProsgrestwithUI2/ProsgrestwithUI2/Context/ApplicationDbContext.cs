using Microsoft.EntityFrameworkCore;
using ProsgrestwithUI2.Model;
using System.Collections.Generic;

namespace ProsgrestwithUI2.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Stu { get; set; }

    }
}
