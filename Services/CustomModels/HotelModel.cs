using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Services.CustomModels.Interfaces;
namespace Services.CustomModels
{
    public class HotelModel : ICustomModel
    {
        public int Id { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }
        public string WebAddress { get; set; }


    }
}
