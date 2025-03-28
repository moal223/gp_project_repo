using gp_backend.Api.Dtos;
using gp_backend.Core.Models;
using gp_backend.EF.MSSql.Data;
using gp_backend.EF.MySql.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace gp_backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyRepo _pharmacyRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public PharmacyController(IPharmacyRepo pharmacyRepo, UserManager<ApplicationUser> userManager)
        {
            _pharmacyRepo = pharmacyRepo;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]AddPharmacyDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BaseResponse(state: false, message: ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList(), null));
            }
            var doctor = await _userManager.FindByIdAsync(model.DoctorId);
            var pharmacy = new Pharmacy { Name = model.Name, Location = model.Location, Doctor = doctor, Close = model.Close, Start = model.Start,
            Fees = model.Fees};
            await _pharmacyRepo.Insert(pharmacy);
            await _pharmacyRepo.SaveChanges();
            return Ok(pharmacy);
        }
        [HttpGet("{location}")]
        public async Task<IActionResult> GetAll([FromRoute]string location)
        {
            var pharmacies = await _pharmacyRepo.GetAll(location);
            if (pharmacies.Count <= 0)
                return NoContent();
            return Ok(pharmacies);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var pharmacy = await _pharmacyRepo.GetById(id);
            return Ok(pharmacy);
        }
    }
}
