using domain.UseCases;
using domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
namespace IT_task.Controllers
{
    [ApiController]
    [Route("visit")]
    public class VisitController : ControllerBase
    {
        private readonly VisitUseCases _usecases;
        public VisitController(VisitUseCases usecases)
        {
            _usecases = usecases;
        }

        [HttpGet("is_visit")]
        public ActionResult IsVisitExists(Visit visit)
        {
            var res = _usecases.IsVisitExist(visit);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpPost("create_visit")]
        public ActionResult CreateVisit(DateTime timeStart, DateTime timeEnd, int userId, int doctorId)
        {
            Visit visit = new Visit(0, timeStart, timeEnd, userId, doctorId);
            var res = _usecases.CreateVisit(visit);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpGet("get_spec")]
        public ActionResult GetAllFreeSpec(Specialization specialization)
        {
            var res = _usecases.GetAllFreeSpec(specialization);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }

        [HttpGet("get_docs")]
        public ActionResult GetAllFreeDocs(Doctor doctor)
        {
            var res = _usecases.GetAllFreeDoctor(doctor);
            if (res.IsFailure)
            {
                return Problem(statusCode: 404, detail: res.Error);
            }
            return Ok(res.Value);
        }
    }
}
