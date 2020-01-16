using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class UserRoles : BaseModel
    {
        public int UserID { get; set; }
        public User User { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
    }
}
