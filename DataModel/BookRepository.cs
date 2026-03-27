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
        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Book> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Find(Expression<Func<Book, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Book entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Book> entities)
        {
            throw new NotImplementedException();
        }

        // Return the member who has this book on loan or null if the book 
        // is not currently on loan
        public Member GetBookLoanee(int BookId)
        {
            throw new NotImplementedException();
        }
    }
}
