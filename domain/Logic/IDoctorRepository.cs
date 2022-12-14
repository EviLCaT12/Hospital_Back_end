using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Models;

namespace domain.Logic
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        bool IsDoctorExist(int id);
        Doctor? GetDoctorBySpecialization(Specialization specialization);
        Doctor? GetDoctorById(int id);
    }
}