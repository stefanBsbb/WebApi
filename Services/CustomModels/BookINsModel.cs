using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Services.CustomModels.Interfaces;

namespace Services.CustomModels
{
    public class BookINsModel : ICustomModel
    {
        public int Id { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int VisitorID { get; set; }
        [Required]
        public int Room { get; set; }
        [Required]
        public DateTime DateBookedIn { get; set; }
        public DateTime? DateBookedOut { get; set; }
        [Required]
        
        public decimal TotalMoneyOwed { get; set; }
        [Required]
        public bool Paid { get; set; }
    }
}
