using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Models
{
    public class TimeTable
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DateTime date { get; set; }


        public TimeTable() : this(0, 0, DateTime.MinValue) { }
        public TimeTable(int id, int doctorId, DateTime date )
        {
            this.Id = id;
            this.DoctorId = doctorId;
            this.date = date;
        }

        public Result IsValid()
        {
            if (date < DateTime.Today)
            {
                return Result.Fail("Non correct time");
            }
            else
            {
                return Result.Ok();
            }
        }
    }
}
