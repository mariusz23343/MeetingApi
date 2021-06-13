using MeetingApi.Models.DbModels;
using MeetingApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Reposiories
{
    public interface IParticipantRepository
    {
        public Task<IList<Participant>> AddParticipantToMeet(ParticipantDTO participant);
        public Task<int> CheckParticipantsNumber(int meetId);
    }
}
