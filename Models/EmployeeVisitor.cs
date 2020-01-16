using System;
using System.Collections.Generic;
using System.Text;
using Models.BaseModels;
namespace Models
{
    public class EmployeeVisitor : BaseModel
    {
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public int VisitorID { get; set; }
        public virtual Visitor Visitor { get; set; }
    }
}
