using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BookRepository : IBookRepository<Book>
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Book entity)
        {
            _context.Books.Add(entity);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<Book> entities)
        {
            _context.Books.AddRange(entities);
            _context.SaveChanges();
        }

        public IEnumerable<Book> Find(Expression<Func<Book, bool>> predicate)
        {
            return _context.Books.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return _context.Books.FirstOrDefault(b => b.BookID == id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public void Remove(Book entity)
        {
            _context.Books.Remove(entity);
            _context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Book> entities)
        {
            _context.Books.RemoveRange(entities);
            _context.SaveChanges();
        }

        // Return the member who has this book on loan or null if the book 
        // is not currently on loan
        public Member GetBookLoanee(int BookId)
        {
            var loan = _context.Loans
                .Where(l => l.BookID == BookId)
                .Select(l => l.Member)
                .FirstOrDefault();

            return loan;
        }
    }
}
