using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class Image : BaseModel
    {
        public string PhotoDir { get; set; }
        public string ImageType { get; set; }
        public int? HotelID { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
