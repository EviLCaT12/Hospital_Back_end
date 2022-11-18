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
    internal class VisitRepo : IVisitRepository
    {
        private readonly ApplicationContext _context;

        public VisitRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Visit item)
        {
            _context.Visits.Add(item.ToModel());
            return true;
        }

        public bool Delete(Visit item)
        {
            var visit = _context.Visits.FirstOrDefault(v => v.Id == item.Id);
            if (visit != null)
            {
                _context.Visits.Remove(visit);
                return true;    
            }
            return false;
        }

        public IEnumerable<Visit> GetAllItem()
        {
            var _visits = _context.Visits.ToList();
            var visits = _context.Visits.Select(v => v.ToDomain()).ToList();
            return visits;
        }

        public IEnumerable<DateTime> GetFreeVisitbySpec(Specialization specialization)
        {
            var doctors = _context.Doctors.Where(d => d.Specialization.ToDomain() == specialization);
            return _context.Visits.Where(a => a.UserId == -1 && doctors.Any(d => d.Id == a.DoctorId)).Select(a => a.TimeStart);
        }

        public IEnumerable<DateTime> GetFreeVisitByDoctor(Doctor doctor)
        {
            return _context.Visits.Where(a => a.UserId == -1 && a.DoctorId== doctor.Id).Select(a => a.TimeStart);
        }

        public Visit? GetItemById(int id)
        {
            var visit = _context.Visits.FirstOrDefault(v => v.Id == id);
            return visit?.ToDomain();
        }

        public bool IsVisitExist(Visit visit)
        {
            return _context.Visits.FirstOrDefault(v => v.Id == visit.Id) != null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Visit item)
        {
            _context.Visits.Update(item.ToModel());
            return true;
        }
    }
}
