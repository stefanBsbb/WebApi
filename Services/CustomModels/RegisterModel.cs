namespace Services.CustomModels
{
    using Models;
    using Newtonsoft.Json;
    using Services.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class RegisterModel
    {
        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }


        [Required]
        [JsonProperty("password")]
        [Password(8, true, true, true, ErrorMessage = "Password isn't meeting the requirements")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match!")]

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; }

    }
}
