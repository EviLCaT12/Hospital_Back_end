using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Logic;
using domain.Models;


namespace domain.UseCases
{
    public class TimeTableUseCases
    {
        private readonly ITimeTableRepository _db;
        private readonly IDoctorRepository _db2;

        public TimeTableUseCases(ITimeTableRepository db, IDoctorRepository db2)
        {
            _db = db;
            _db2 = db2;
        }

        public Result<TimeTable> CreateTimeTable (TimeTable timeTable)
        {
            var res = timeTable.IsValid();
            if (res.IsFailure)
            {
                return Result.Fail<TimeTable>("Invalid input data:" + res.Error);
            }
            return _db.Create(timeTable) ? Result.Ok(timeTable) : Result.Fail<TimeTable>("Error while creating.Try again later");
        }

        public Result<TimeTable> UpdateTimeTable(TimeTable timeTable)
        {
            var res = timeTable.IsValid();
            if (res.IsFailure)
            {
                return Result.Fail<TimeTable>("Invalid input data:" + res.Error);
            }
            return _db.Update(timeTable) ? Result.Ok(timeTable) : Result.Fail<TimeTable>("Error while updating.Try again later");
        }

        public Result<TimeTable> GetTimeTableByDoctorAndDate (Doctor doctor, DateTime date)
        {
            if (!_db2.IsDoctorExist(doctor.Id))
            {
                return Result.Fail<TimeTable>("Doctor not found");
            }

            var res = _db.GetTimeTableByDoctorAndDate(doctor, date);
            return res != null ? Result.Ok(res) : Result.Fail<TimeTable>("Error while getting timetable.Try again later");
        }
    }
}
