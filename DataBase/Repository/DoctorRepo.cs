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
    public class DoctorRepo : IDoctorRepository
    {
        private readonly ApplicationContext _context;

        public DoctorRepo(ApplicationContext context)
        {
            _context = context;
        }

        public bool Create(Doctor item)
        {
            var doctor = _context.Doctors.Add(item.ToModel());
            return true;
        }

        public bool Delete(Doctor item)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == item.Id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                return true;
            }
            return false;
        }

        public IEnumerable<Doctor> GetAllItem()
        {
            var _doctors = _context.Doctors.ToList();
            var doctors = _doctors.Select(x => x.ToDomain()).ToList();
            return doctors;
        }

        public Doctor? GetDoctorById(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            return doctor?.ToDomain();  
        }

        public Doctor? GetDoctorBySpecialization(Specialization specialization)
        {
            var doctor = _context.Doctors.First(d => d.Specialization.ToDomain() == specialization);
            return doctor?.ToDomain();
        }

        public Doctor? GetItemById(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            return doctor?.ToDomain();
        }

        public bool IsDoctorExist(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            return doctor != null;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Doctor item)
        {
            _context.Doctors.Update(item.ToModel());
            return true;
        }
    }
}
