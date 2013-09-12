using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.Data;

namespace Web.Service
{
    public interface IWorkContext
    {
        /// <summary>
        /// Gets or sets the current customer
        /// </summary>
        Customer CurrentCustomer { get; set; }

    }
}
