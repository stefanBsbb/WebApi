using System;
using System.Collections.Generic;
using System.Text;
using Services.CustomModels.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Services.CustomModels
{
    public class EmployeeModel : ICustomModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public string LastName { get; set; }

        public string Title { get; set; }

        public string EGN { get; set; }

        public DateTime Hiredate { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public int HotelID { get; set; }

    }
}
