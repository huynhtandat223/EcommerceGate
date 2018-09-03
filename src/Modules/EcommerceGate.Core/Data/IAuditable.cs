﻿using System;

namespace EcommerceGate.Core.Data
{
    public interface IAuditable
    {
        string UpdatedUser { set; get; }
        string CreatedUser { set; get; }
        DateTime? CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
