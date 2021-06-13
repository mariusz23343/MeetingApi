using MeetingApi.Mappers;
using MeetingApi.Models.DbModels;
using MeetingApi.Models.DTOs;
using MeetingApi.Reposiories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MeetingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        private readonly IParticipantRepository _repository;
        private readonly IMeetMapper _mapper;
        public ParticipantsController(IParticipantRepository repository, IMeetMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipantDTO dto)
        {
            if(await _repository.CheckParticipantsNumber(dto.MeetId) < 25)
            {
                var participants = await _repository.AddParticipantToMeet(dto);
                var participantsToReturn = _mapper.MapResponse(participants);

                return Ok(participantsToReturn);
            }

            return BadRequest("Nie można dodać kolejnego uczestnika, osiągnięto limit na tym spotkaniu");
            
        }

        


    }
}
