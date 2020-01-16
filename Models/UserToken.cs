using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class UserToken : BaseModel
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}
