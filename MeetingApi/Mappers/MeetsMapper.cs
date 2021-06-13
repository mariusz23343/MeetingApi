using MeetingApi.Mappers;
using MeetingApi.Models.DbModels;
using MeetingApi.Models.DbModels.DTOs;
using MeetingApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi
{
    public  class MeetsMapper : IMeetMapper
    {
        public  IList<MeetDTO> MapResponse(IList<Meet> newMeetList)
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
        public  IList<ParticipantDTO> MapResponse(IList<Participant> participants)
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
