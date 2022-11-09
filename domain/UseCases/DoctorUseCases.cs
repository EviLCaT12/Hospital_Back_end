using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Logic;
using domain.Models;

namespace domain.UseCases
{
    public class DoctorUseCases
    {
        private readonly IDoctorRepository _db;

        public DoctorUseCases(IDoctorRepository db)
        {
            _db = db;
        }

        public Result<Doctor> CreateDoctor(Doctor doctor)
        {
            var isValid = doctor.IsValid();
            if (isValid.IsFailure)
            {
                return Result.Fail<Doctor>("Invalid input data:" + isValid.Error);
            }
            else if (_db.IsDoctorExist(doctor.Id))
            {
                return Result.Fail<Doctor>("Doctor is already exist");
            }
            else
            {
                return _db.CreateDoctor(doctor) ? Result.Ok(doctor) : Result.Fail<Doctor>("Error while creating.Try again later");
            }
        }

        public Result<Doctor> DeleteDoctor(int id)
        {
            //Сделать невозможным удаление доктора с записями
            var res = GetDoctorById(id);
            if (res.IsFailure)
            {
                return Result.Fail<Doctor>("There is no such doctor");
            }

            return _db.DeleteDoctor(id) ? res : Result.Fail<Doctor>("Error while deleting.Try again later");
        }

        public Result<IEnumerable<Doctor>> GetAllDoctors()
        {
            return Result.Ok(_db.GetAllDoctors());
        }

        public Result<Doctor> GetDoctorById(int id)
        {
            if (id < 0)
            {
                return Result.Fail<Doctor>("Non correct id");
            }

            var doctor = _db.GetDoctorById(id);
            return doctor != null ? Result.Ok(doctor) : Result.Fail<Doctor>("Doctor not found"); 
        }

        public Result<Doctor> GetDoctorBySpecialization(Specialization specialization)
        {
            var isValid = specialization.isValid();

            if (isValid.IsFailure)
            {
                return Result.Fail<Doctor>("Invalid input data:" + isValid.Error);
            }

            var doctor = _db.GetDoctorBySpecialization(specialization);
            return doctor != null ? Result.Ok(doctor) : Result.Fail<Doctor>("Doctor not found");
        }

        public Result<bool> IsDoctorExist(int id)
        {
            if (!_db.IsDoctorExist(id))
            {
                return Result.Fail<bool>("Doctor is not found");
            }
            else
            {
                return Result.Ok(_db.IsDoctorExist(id));
            }
        }
    }
}
