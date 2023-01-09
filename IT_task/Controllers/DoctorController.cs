using domain.UseCases;
using domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace IT_task.Controllers
{
    [ApiController]
    [Route("doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorUseCases _usecases;
        public DoctorController(DoctorUseCases usecases)
        {
            _usecases = usecases;
        }

        [HttpPost("create_doctor")]
        public ActionResult CreateDoctor(string fullName, Specialization specialization)
        {
            Doctor doctor = new Doctor(0, fullName, specialization);
            var doctorRes = _usecases.CreateDoctor(doctor);
            if(doctorRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: doctorRes.Error);
            }
            return Ok(doctorRes.Value);
        }

        [HttpDelete("delete_doctor")]
        public ActionResult DeleteDoctor(Doctor doctor) 
        {
            var doctorRes = _usecases.DeleteDoctor(doctor);
            if (doctorRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: doctorRes.Error);
            }
            return Ok(doctorRes.Value);
        }

        [HttpGet("get_idoctor")]
        public ActionResult GetDoctorById(int id) 
        {
            var doctorRes = _usecases.GetDoctorById(id);
            if(doctorRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: doctorRes.Error);
            }
            return Ok(doctorRes.Value);
        }

        [HttpGet("get_sdoctor")]
        public ActionResult GetDoctorBySpec(Specialization specialization)
        {
            var doctorRes = _usecases.GetDoctorBySpecialization(specialization);
            if (doctorRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: doctorRes.Error);
            }
            return Ok(doctorRes.Value);
        }

        [HttpGet("check")]
        public ActionResult IsDoctorExists (int id)
        {
            var doctorRes = _usecases.IsDoctorExist(id);
            if (doctorRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: doctorRes.Error);
            }
            return Ok(doctorRes.Value);
        }

        [HttpGet("all_doctors")]
        public ActionResult GetAllDoctors()
        {
            var doctorRes = _usecases.GetAllDoctor();
            if (doctorRes.IsFailure)
            {
                return Problem(statusCode: 404, detail: doctorRes.Error);
            }
            return Ok(doctorRes.Value);
        }
    }
}
