﻿using MeetingApi.Models.DbModels;
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

        public MeetsController(IMeetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost] //tworzenie spotkania 
        public async Task <IActionResult> Post([FromBody] MeetDTO dto)
        {
            var newMeetList = await _repository.AddMeet(dto);
            List<MeetDTO> meetsToReturn = MapResponse(newMeetList);

            return Ok(meetsToReturn);
        }

        [HttpDelete] // usunięcie spotkania 
        public async Task<IActionResult> DeleteMeet([FromQuery] int id)
        {
            var newMeetList = await _repository.DeleteMeet(id);
            List<MeetDTO> meetsToReturn = MapResponse(newMeetList);
            return Ok(meetsToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var newMeetList = await _repository.GetMeetsList();
            List<MeetDTO> meetsToReturn = MapResponse(newMeetList);
            return Ok(meetsToReturn);
        }
        private static List<MeetDTO> MapResponse(List<Meet> newMeetList)
        {
            var meetsToReturn = new List<MeetDTO>();
            foreach (var item in newMeetList)
            {
                meetsToReturn.Add(new MeetDTO
                {
                    MeetDate = item.MeetDate,
                    MeetName = item.MeetName
                });
            }
            return meetsToReturn;
        }

    }
}