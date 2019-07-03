﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Domain.Enums
{
    public enum State: int
    {
        Free=1,
        Booked,
        Busy,
        NotAvailable
    }
}