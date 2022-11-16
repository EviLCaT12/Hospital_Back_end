using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Models
{
    public class TimeTableModel
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }

        public DateTime date { get; set; }
    }
}
