using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public interface IBookRepository<T> : IRepository<T> where T : Book
    {
        Member GetBookLoanee(int BookId);
    }
}
