using System;
using System.Collections.Generic;
using System.Text;
using Services.CustomModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Services.CustomModels
{
    public class EmployeeModel : ICustomModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string EGN { get; set; }
        [Required]
        public DateTime Hiredate { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }
        [Required]
        public int HotelID { get; set; }

    }
}
