using MeetingApi.Mappers;
using MeetingApi.Models.DbModels;
using MeetingApi.Models.DbModels.DTOs;
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
    public class MeetsController : ControllerBase
    {
        private readonly IMeetRepository _repository;
        private readonly IMeetMapper _mapper;

        public MeetsController(IMeetRepository repository, IMeetMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost] 
        public async Task <IActionResult> Post([FromBody] MeetDTO dto)
        {
            var newMeetList = await _repository.AddMeet(dto);
            var meetsToReturn = _mapper.MapResponse(newMeetList);

            return Ok(meetsToReturn);
        }

        [HttpDelete]  
        public async Task<IActionResult> DeleteMeet([FromQuery] int id)
        {
            var newMeetList = await _repository.DeleteMeet(id);

            if (newMeetList == null) 
                return NotFound("Nie znaleziono spotkania o podanym ID");

            var meetsToReturn = _mapper.MapResponse(newMeetList);
            return Ok(meetsToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var newMeetList = await _repository.GetMeetsList();
            var meetsToReturn = _mapper.MapResponse(newMeetList);
            return Ok(meetsToReturn);
        }
        

    }
}
