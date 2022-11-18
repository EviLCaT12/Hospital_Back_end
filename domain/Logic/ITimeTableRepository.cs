using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Models;

namespace domain.Logic
{
    public interface ITimeTableRepository : IRepository<TimeTable>
    {
        TimeTable? GetTimeTableByDoctorAndDate(Doctor doctor, DateTime date);
    }
}
