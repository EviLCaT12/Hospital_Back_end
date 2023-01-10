using domain.UseCases;
using domain.Logic;
using domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT_task.Controllers
{
    [ApiController]
    [Route("specialization")]
    public class SpecController : ControllerBase
    {
        private readonly ISpecRepository _repo;
        public SpecController(ISpecRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("all_specialization")]
        public ActionResult GetAllSpecialization() 
        {
            var res = _repo.GetAllItem();
            return Ok(res);
        }
    }
}
