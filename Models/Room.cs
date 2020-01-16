using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class Room : BaseModel
    {
        public int RoomNumber { get; set; }
        public bool Taken { get; set; }
    }
}
