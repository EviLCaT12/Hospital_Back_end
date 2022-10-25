using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    class Doctor
    {
        string Id { get; set; }
        string FullName { get; set; }

        Specialization specialization { get; set; }
    }
}
