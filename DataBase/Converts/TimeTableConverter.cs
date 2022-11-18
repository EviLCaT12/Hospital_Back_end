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
                Id= model.Id,  
                DoctorId = model.DoctorId,
                date = model.date
            };
        }

        public static TimeTableModel? ToModel(this TimeTable model)
        {
            return new TimeTableModel
            {
                Id = model.Id,
                DoctorId = model.DoctorId,
                date = model.date
            };
        }
    }
}
