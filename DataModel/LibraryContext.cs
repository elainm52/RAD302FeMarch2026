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
            var myconnectionstring = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = RAD302fe2026db-S00250500";
            optionsBuilder.UseSqlServer(myconnectionstring)
                            .EnableSensitiveDataLogging();

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().HasKey(l => new {l.BookID, l.MemberID});

            // Seed Members
            modelBuilder.Entity<Member>().HasData(
                new Member { MemberID = 1, FirstName = "Elizabeth", SecondName = "Anderson" },
                new Member { MemberID = 2, FirstName = "Catherine", SecondName = "Autier Miconi" },
                new Member { MemberID = 3, FirstName = "Thomas", SecondName = "Axen" },
                new Member { MemberID = 4, FirstName = "Jean Phillipe", SecondName = "Bagel" },
                new Member { MemberID = 5, FirstName = "Anna", SecondName = "Bedecs" },
                new Member { MemberID = 6, FirstName = "John", SecondName = "Edwards" },
                new Member { MemberID = 7, FirstName = "Alexanger", SecondName = "Eggerer" },
                new Member { MemberID = 8, FirstName = "Michael", SecondName = "Entin" },
                new Member { MemberID = 9, FirstName = "Daniel", SecondName = "Goldschmidt" },
                new Member { MemberID = 10, FirstName = "Antonio", SecondName = "Gratacos Silsona" },
                new Member { MemberID = 11, FirstName = "Carlos", SecondName = "Grilo" },
                new Member { MemberID = 12, FirstName = "Jonas", SecondName = "Hasselberg" }

            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { BookID = 1, Title = "The Hunger Gamer", ISBN = "9780439023481.00", Author = "Suzanne Collins", LoanType = LoanType.General, LoanDuration = 28 },
                new Book { BookID = 2, Title = "1984", ISBN = "1110141036141.00", Author = "George Orwell", LoanType = LoanType.General, LoanDuration = 28 },
                new Book { BookID = 3, Title = "Brave New World", ISBN = "2220060929871.00", Author = "Aldous Huxely", LoanType = LoanType.Restricted, LoanDuration = 1 },
                new Book { BookID = 4, Title = "The Hound of the Baskervilles", ISBN = "1234564389.00", Author = "Athur Conan Doyle", LoanType = LoanType.General, LoanDuration = 28 },
                new Book { BookID = 5, Title = "Literary works of Leonardo da Vinci", ISBN = "123456789196.00", Author = "Leonardo da Vinci", LoanType = LoanType.Restricted, LoanDuration = 1 },
                new Book { BookID = 6, Title = "The Arctic Incident", ISBN = "9780786851478.00", Author = "Eoin Colfer", LoanType = LoanType.General, LoanDuration = 28 },
                new Book { BookID = 7, Title = "Physical Chemistry", ISBN = "716720736.00", Author = "P.W Atkins", LoanType = LoanType.Restricted, LoanDuration = 1 },
                new Book { BookID = 8, Title = "Universe", ISBN = "716746476.00", Author = "Roger Freedman", LoanType = LoanType.General, LoanDuration = 28 }
            );

            // Seed Loans
            modelBuilder.Entity<Loan>().HasData(
                new Loan { BookID = 1, MemberID = 1, LoanIssueDate = new DateTime(2026, 05, 12) },
                new Loan { BookID = 2, MemberID = 1, LoanIssueDate = new DateTime(2026, 10, 17) },
                new Loan { BookID = 3, MemberID = 5, LoanIssueDate = new DateTime(2026, 12, 12) },
                new Loan { BookID = 4, MemberID = 6, LoanIssueDate = new DateTime(2026, 10, 21) },
                new Loan { BookID = 7, MemberID = 8, LoanIssueDate = new DateTime(2026, 11, 23) }
            );

            base.OnModelCreating(modelBuilder);
        }


    }
}
