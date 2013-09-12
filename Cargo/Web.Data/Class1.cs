using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.Data
{
    public class Class1
    {
        public void testlinq()
        {
            DBDataClassesDataContext context = new DBDataClassesDataContext();
            context.Customers.ToList();
        }
    }
}
