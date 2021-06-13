using MeetingApi.Models.DbModels;
using MeetingApi.Models.DbModels.DTOs;
using MeetingApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Mappers
{
    public interface IMeetMapper
    {
        public  IList<MeetDTO> MapResponse(IList<Meet> newMeetList);
        public IList<ParticipantDTO> MapResponse(IList<Participant> participants);
    }
}
