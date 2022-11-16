using domain.Models;
using DataBase.Models;
using System.Runtime.CompilerServices;

namespace DataBase.Converts
{
    public static class TimeTableConverter
    {
        public static TimeTable? ToDomain(this TimeTableModel model)
        {
            return new TimeTable
            {
                DoctorId = model.DoctorId,
                TimeEnd = model.TimeEnd,
                TimeStart = model.TimeStart
            };
        }

        public static TimeTableModel? ToModel(this TimeTable model)
        {
            return new TimeTableModel
            {
                DoctorId = model.DoctorId,
                TimeEnd = model.TimeEnd,
                TimeStart = model.TimeStart
            };
        }
    }
}
