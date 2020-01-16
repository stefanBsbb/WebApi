using System;
using System.Collections.Generic;
using System.Text;
using Services.CustomModels.Interfaces;
namespace Services.CustomModels
{
    public class BookINsModel : ICustomModel
    {
        public int Id { get; set; }
        public int EmployeeID { get; set; }
   
        public int VisitorID { get; set; }
        public int Room { get; set; }
        public DateTime DateBookedIn { get; set; }
        public DateTime? DateBookedOut { get; set; }
        public decimal TotalMoneyOwed { get; set; }
        public bool Paid { get; set; }
    }
}
