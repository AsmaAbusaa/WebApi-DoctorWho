using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Controller]
    [Route("api/doctors")]
    public class DoctorsController : Controller
    {
        private readonly DoctorRepository _doctorRepository;
        private readonly IValidator<Doctor> _validator;
        private readonly IMapper _mapper;

        public DoctorsController(DoctorRepository doctorRepository,
            IValidator<Doctor> validations, IMapper mapper)
        {
            this._doctorRepository = doctorRepository ??
                                throw new ArgumentNullException(nameof(doctorRepository));
            this._validator = validations;
            this._mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors(bool includeEpiosdes)
        {
            var result = await _doctorRepository.GetAllDoctors(includeEpiosdes);
            return includeEpiosdes ?
                Ok(_mapper.Map<IEnumerable<DoctorDto>>(result))
             : Ok(_mapper.Map<IEnumerable<DoctorDtoWithoutEpisodes>>(result));
        }

        [HttpGet("{id}", Name = "GetDoctor")]
        public async Task<IActionResult> GetDoctor(int id, bool includeEpiosdes)
        {
            var doctor = await _doctorRepository.GetDoctor(id, includeEpiosdes);

            if (doctor == null)
                return NotFound();

            return includeEpiosdes ?
                 Ok(_mapper.Map<DoctorDto>(doctor))
             : Ok(_mapper.Map<DoctorDtoWithoutEpisodes>(doctor));

        }

        [HttpPost]
        public async Task<IActionResult> InsertDoctor([FromBody]
            DoctorDtoWithoutEpisodes doctorDtowithoutEpisodes)
        {
            if (doctorDtowithoutEpisodes.FirstEpisodeDate == null)
            {
                doctorDtowithoutEpisodes.FirstEpisodeDate = new DateTime();
                doctorDtowithoutEpisodes.LastEpisodeDate = new DateTime();
            }
            var doctor = _mapper.Map<Doctor>(doctorDtowithoutEpisodes);
            ValidationResult result = await _validator.ValidateAsync(doctor);

            if (!result.IsValid)
                return BadRequest(result.Errors);

            _doctorRepository.AddDoctor(doctor);


            return new ObjectResult(doctorDtowithoutEpisodes);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor(int id, [FromBody]
            DoctorDtoWithoutEpisodes doctorDtowithoutEpisodes)
        {
            var doctorEntity = await _doctorRepository.GetDoctor(id);

            if (doctorEntity == null)
                return NotFound();
            var doctorToValidate = _mapper.Map<Doctor>(doctorDtowithoutEpisodes);
            ValidationResult result = await _validator.ValidateAsync(doctorToValidate);
            if (!result.IsValid)
                foreach (var e in result.Errors)
                    return BadRequest(e.ErrorMessage);

            _mapper.Map(doctorDtowithoutEpisodes, doctorEntity);
            await _doctorRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartiallyUpdateDoctor(int id,
         [FromBody] JsonPatchDocument<DoctorDtoWithoutEpisodes> doctorJsonDoc)
        {
            var doctorEntity = await _doctorRepository.GetDoctor(id);
            var doctorDtowithoutEpiosdes = _mapper.Map<DoctorDtoWithoutEpisodes>(doctorEntity);

            doctorJsonDoc.ApplyTo(doctorDtowithoutEpiosdes, ModelState);

            var doctorToValidate = _mapper.Map<Doctor>(doctorDtowithoutEpiosdes);
            var result = _validator.Validate(doctorToValidate);

            if (!result.IsValid)
                return BadRequest(result.Errors);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _mapper.Map(doctorDtowithoutEpiosdes, doctorEntity);
            await _doctorRepository.SaveChangesAsync();

            return Ok("Done Sucssefully");

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            return await _doctorRepository.DeleteDoctor(id);
        }


    }
}
