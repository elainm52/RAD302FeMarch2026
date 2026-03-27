using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LibraryContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }

        public LibraryContext() : base()
        {
            // Seeding to be done in Seeder after we add the context
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RAD302fe2026db-ppowell";
            optionsBuilder.UseSqlServer(myconnectionstring)
                            .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasKey(l => new {l.BookID, l.MemberID});
            base.OnModelCreating(modelBuilder);
        }


    }
}
