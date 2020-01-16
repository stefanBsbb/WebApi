using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class Hotel : BaseModel
    {

        public string HotelName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string WebAddress { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Visitor> Visitors { get; set; }

    }
}
