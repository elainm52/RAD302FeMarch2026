using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LoanMap : ClassMap<Loan>
    {
        public LoanMap()
        {
            string format = "dd/MM/yyyy";
            var msMY = CultureInfo.GetCultureInfo("en-ie");
            //Map(m => m.LoanID).Name("LoanID");
            //Map(m => m.LoanID).Constant(-1);
            Map(m => m.MemberID).Name("MemberID");
            Map(m => m.BookID).Name("BookID");
            Map(m => m.LoanIssueDate).Name("LoanIssueDate")
                .TypeConverterOption.Format(format)
                .TypeConverterOption.CultureInfo(msMY);

            Map(m => m.MemberID).Name("MemberID");
        }



    }
}
