using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int UserId { get; set; }
        public int DoctorId { get; set; }

        public Visit() : this(DateTime.MinValue, DateTime.MinValue, 0, 0) { }
        public Visit(DateTime start, DateTime end, int userId, int doctorId)
        {
            TimeStart = start;
            TimeEnd = end;
            UserId = userId;
            DoctorId = doctorId;
        }

        public Result IsValid()
        {
            if (TimeStart >= TimeEnd)
            {
                return Result.Fail("Non correct visit`s time");
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}
