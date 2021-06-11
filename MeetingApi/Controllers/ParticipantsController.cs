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
        private readonly IParticipantReposiotry _repository;
        public ParticipantsController(IParticipantReposiotry participant)
        {
            _repository = participant;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ParticipantDTO dto)
        {
            if(await _repository.CheckParticipantsNumber(dto.MeetId) < 25)
            {
                var participants = await _repository.AddParticipantToMeet(dto);
                List<ParticipantDTO> participantsToReturn = MapResponse(participants);

                return Ok(participantsToReturn);
            }

            return BadRequest("Nie można dodać kolejnego uczestnika, osiągnięto limit na tym spotkaniu");
            
        }

        private static List<ParticipantDTO> MapResponse(List<Participant> participants)
        {
            var participantsToReturn = new List<ParticipantDTO>();
            foreach (var item in participants)
            {
                participantsToReturn.Add(new ParticipantDTO
                {
                    Email = item.Email,
                    ParticipantName = item.ParticipantName,
                    MeetId = item.FkMeet
                });
            }

            return participantsToReturn;
        }


    }
}
