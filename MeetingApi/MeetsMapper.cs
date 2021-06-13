using MeetingApi.Models.DbModels;
using MeetingApi.Models.DbModels.DTOs;
using MeetingApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi
{
    public static  class MeetsMapper
    {
        public static List<MeetDTO> MapResponse(List<Meet> newMeetList)
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
        public static List<ParticipantDTO> MapResponse(List<Participant> participants)
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
