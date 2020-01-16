using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class BookIn : BaseModel
    {
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public int VisitorID { get; set; }
        public virtual Visitor Visitor { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }
        public DateTime DateBookedIn { get; set; }
        public DateTime? DateBookedOut { get; set; }
        public decimal TotalMoneyOwed { get; set; }
        public bool Paid { get; set; }
        
    }
}
