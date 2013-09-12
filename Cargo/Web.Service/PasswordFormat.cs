using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Service
{
    public enum PasswordFormat : int
    {
        Clear = 0,
        Hashed = 1,
        Encrypted = 2
    }
}
