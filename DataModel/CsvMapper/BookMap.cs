using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class BookMap : ClassMap<Book>  
    {
        public BookMap()
        {
            Map(m => m.BookID).Name("BookID");
            Map(m => m.Title).Name("Title");
            Map(m => m.ISBN).Name("ISBN");
            Map(m => m.Author).Name("Author");
            Map(m => m.LoanType).Name("LoanType");
            Map(m => m.LoanDuration).Name("LoanDuration");

        }
    }
}
