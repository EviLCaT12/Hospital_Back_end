using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Logic;
using domain.Models;


namespace domain.UseCases
{
    public class VisitUseCases
    {
        private readonly IVisitRepository _db;
        private readonly IDoctorRepository _db2;

        public VisitUseCases(IVisitRepository db, IDoctorRepository db2)
        {
            _db = db;
            _db2 = db2;
        }

        public Result<bool> IsVisitExist (Visit visit)
        {
          if (!_db.IsVisitExist(visit))
            {
                return Result.Fail<bool>("Visit not found");
            }
          else
            {
                return Result.Ok(_db.IsVisitExist(visit));
            }
        }

        public Result<Visit> CreateVisit (Visit visit)
        {
            var res = visit.IsValid();
            if (res.IsFailure)
            {
                return Result.Fail<Visit>("Invalid input data:" + res.Error);
            }
            if (_db.IsVisitExist(visit))
            {
                return Result.Fail<Visit>("This visit is already exist");
            }
            return _db.Create(visit) ? Result.Ok(visit) : Result.Fail<Visit>("Error while creating visit. Try again later");
        }
            
        public Result<IEnumerable<DateTime>> GetAllFreeSpec(Specialization specialization)
        {
            var list = _db.GetFreeVisitbySpec(specialization);
            return Result.Ok(list);
        }

        public Result<IEnumerable<DateTime>> GetAllFreeDoctor(Doctor doctor)
        {
            if(!_db2.IsDoctorExist(doctor.Id))
            {
                return Result.Fail<IEnumerable<DateTime>>("Doctor not found");
            }
            var list = _db.GetFreeVisitByDoctor(doctor);
            return Result.Ok(list);
        }
    }
}
