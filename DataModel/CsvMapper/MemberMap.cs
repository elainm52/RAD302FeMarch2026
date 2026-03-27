using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class MemberMap : ClassMap<Member>  
    {
        public MemberMap()
        {
            //Map(m => m.ID).Name("ID");
            Map(m => m.MemberID).Name("MemberID");
            Map(m => m.FirstName).Name("FirstName");
            Map(m => m.SecondName).Name("SecondName");
        }
    }
}
