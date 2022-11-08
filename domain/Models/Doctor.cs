using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models 
{
    public class Doctor
    {
        int Id { get; set; }
        string FullName { get; set; }

        Specialization specialization { get; set; }
    }
}
