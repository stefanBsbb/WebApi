using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ICMDat
    {
        DateTime CreatedAt { get; set; }
        DateTime? ModifiedAt { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
