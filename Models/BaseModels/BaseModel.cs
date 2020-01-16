using System;
using System.Collections.Generic;
using System.Text;
using Models.Interfaces;
namespace Models.BaseModels
{
    public class BaseModel : IBaseModel, ICMDat
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
