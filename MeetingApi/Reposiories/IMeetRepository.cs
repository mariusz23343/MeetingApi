using MeetingApi.Models.DbModels;
using MeetingApi.Models.DbModels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Reposiories
{
    public interface IMeetRepository
    {
        public  Task<List<Meet>> AddMeet(MeetDTO meetDTO);
        public  Task<List<Meet>> DeleteMeet(int meetId);
        public  Task<List<Meet>> GetMeetsList();

    }
}
