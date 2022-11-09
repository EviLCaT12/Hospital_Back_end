using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class TimeTable
    {
        int DoctorId { get; set; }
        DateTime TimeStart { get; set; }
        DateTime TimeEnd { get; set; }

        public TimeTable(int doctorId, DateTime start, DateTime end)
        {
            DoctorId = doctorId;
            TimeStart = start;
            TimeEnd = end;
        }
    }
}
