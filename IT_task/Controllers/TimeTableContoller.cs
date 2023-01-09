using domain.UseCases;
using domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace IT_task.Controllers
{
    [ApiController]
    [Route("timeTable")]
    public class TimeTableContoller : ControllerBase
    {
        private readonly TimeTableUseCases _usecases;
        public TimeTableContoller(TimeTableUseCases usecases)
        {
            _usecases = usecases;
        }

        [HttpPost("create_timeTable")]
        public ActionResult CreateTimeTable(int doctorId, DateTime date)
        {
            TimeTable timeTable = new TimeTable(0,doctorId, date);
            var res = _usecases.CreateTimeTable(timeTable);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpPut("update_timeTable")]
        public ActionResult UpdateTimeTable(int id, int doctorId, DateTime date)
        {
            var res = _usecases.UpdateTimeTable(new TimeTable(id, doctorId, date));
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpGet("get_timeTable")]
        public ActionResult GetTimeTable(Doctor doctor, DateTime date) 
        {
            var res = _usecases.GetTimeTableByDoctorAndDate(doctor, date);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }
    }
}
