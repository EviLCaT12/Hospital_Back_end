using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    class Visit
    {
        int Id { get; set; }
        DateTime TimeStart { get; set; }
        DateTime TimeEnd { get; set; }
        int  UserId { get; set; }
        int  DoctorId { get; set; }
    }
}
