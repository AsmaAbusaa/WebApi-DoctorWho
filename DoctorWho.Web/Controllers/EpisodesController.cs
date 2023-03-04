using AutoMapper;
using DoctorWho.Db.Entities;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Controller]
    [Route("api/episodes")]
    public class EpisodesController : Controller
    {
        private readonly EpisodeRepository _episodeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Episode> _validator;
        

        public EpisodesController(EpisodeRepository episodeRepository,
            IMapper mapper, IValidator<Episode> validator)
        {
            this._episodeRepository = episodeRepository;
            this._mapper = mapper;
            this._validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EpisodeDtoWithoutCompEnem>>> GetEpisodes()
        {
            var episodes = await _episodeRepository.GetEpisodes();
            var episodesDtowithoutCompEnem = _mapper.Map<IEnumerable<EpisodeDtoWithoutCompEnem>>(episodes);
            return Ok(episodesDtowithoutCompEnem);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEpisode(int id)
        {
            var episodeEntity = await _episodeRepository.GetEpisode(id);

            if (episodeEntity == null)
                return NotFound();
            return Ok(_mapper.Map<EpisodeDtoWithoutCompEnem>(episodeEntity));

        }

        [HttpPost]
        public async Task<IActionResult> InsertEpisdoe([FromBody] EpisodeDtoWithoutCompEnem episode)
        {
            var episdoeEntity = _mapper.Map<Episode>(episode);
            var result = await _validator.ValidateAsync(episdoeEntity);
            if (!result.IsValid)
                return BadRequest(result);

            await _episodeRepository.AddEpisode(episdoeEntity);

            return new ObjectResult(_mapper.Map<EpisodeDtoToCreation>(episdoeEntity));
        }

        [HttpPost("{episodeId}/enemies")]
        public async Task<IActionResult> AddEnemyToEpisode(int episodeId, [FromBody] EnemyDto enemyDto)
        {
            return await _episodeRepository.AddEnemyToEpisode(enemyDto.EnemyId, episodeId);
        }

        [HttpPost("{episodeId}/companions")]
        public async Task<IActionResult> AddCompanionToEpisode(int episodeId, [FromBody] CompanionDto companionDto)
        {
            return await _episodeRepository.AddCompanionToEpisode(companionDto.CompanionId, episodeId);
        }
    }
}
