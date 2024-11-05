using Hospital.DTOs;
using Hospital.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepo _repo;
        public DoctorController(IDoctorRepo doctorRepo)
        {
            _repo = doctorRepo;
        }
        [AllowAnonymous]
        [HttpGet("{name}")]
        public IActionResult DisplayDoctorbyName(string name)
        {
            var doctordto = _repo.GetDoctorByName(name);

            if (!ModelState.IsValid || doctordto == null)
            {
                return BadRequest(ModelState);
            }

            return Ok(doctordto);
        }
        [HttpPost]
        public IActionResult InsertDoctor(DoctorDto doctordto)
        {
            _repo.AddDoctor(doctordto);

            return Created();
        }
    }
}
