using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    class User
    {
        int Id { get; set; }
        string PhoneNumber { get; set; }
        string FullName { get; set; }
        Role role { get; set; }

    }
}
