using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    class User
    {
        private readonly string id = Guid.NewGuid().ToString();
        private int telephone_number;
        private string last_name;
        private string first_name;
        private string middle_name;
        private string role;
    }
}
