using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Services.CustomModels.Interfaces;
namespace Services.CustomModels
{
    public class RoomModel : ICustomModel
    {
        public int Id { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public bool Taken { get; set; }
    }
}
