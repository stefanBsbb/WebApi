using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class Employee : BaseModel
    {
  

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

        public virtual Hotel Hotel { get; set; }


    }
}
