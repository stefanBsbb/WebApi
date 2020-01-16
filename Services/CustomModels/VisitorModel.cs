using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using Services.CustomModels.Interfaces;
namespace Services.CustomModels
{
    public class VisitorModel : ICustomModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string City { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        public int HotelID { get; set; }
    }
}
