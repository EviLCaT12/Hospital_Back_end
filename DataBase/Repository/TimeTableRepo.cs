using DataBase.Converts;
using domain.Logic;
using domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    internal class TimeTableRepo : ITimeTableRepository
    {
        private readonly ApplicationContext _context;

        public TimeTableRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(TimeTable item)
        {
            var timeTable = _context.TimeTables.Add(item.ToModel());
            return true;
        }

        public bool Delete(TimeTable item)
        {
            var timeTable = GetItemById(item.Id);
            if (timeTable != null)
            {
                _context.Remove(item);
                return true;
            }
            return false;
        }

        public IEnumerable<TimeTable> GetAllItem()
        {
            var _timeTables = _context.TimeTables.ToList();
            var timeTables = _timeTables.Select(x => x.ToDomain()).ToList();
            return timeTables;
        }

        public TimeTable? GetItemById(int id)
        {
            var timeTable = _context.TimeTables.FirstOrDefault(t => t.Id == id);
            return timeTable?.ToDomain();
        }

        public TimeTable? GetTimeTableByDoctorAndDate(Doctor doctor, DateTime date)
        {
            var _doctor = _context.Doctors.FirstOrDefault(d => d.Id == doctor.Id);
            var _timeTable = _context.TimeTables.FirstOrDefault(t => t.date == date);
            var res = _context.TimeTables.FirstOrDefault(t => t.DoctorId == _doctor.Id && t.date == _timeTable.date);
            return res?.ToDomain();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(TimeTable timeTable)
        {
            _context.Update(timeTable);
            return true;
        }
    }
}
