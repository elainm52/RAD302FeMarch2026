using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    [Table("Loan")]
    public class Loan
    {
        //[Column(Order = 0)]
        public int MemberID { get; set; }
        //[Column(Order = 1)]
        public int BookID { get; set; }

        [Column(TypeName="date")]
        public DateTime LoanIssueDate { get; set; }
        [ForeignKey("BookID")]
        public virtual Book? Book { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member? Member { get; set; }
    }
}
