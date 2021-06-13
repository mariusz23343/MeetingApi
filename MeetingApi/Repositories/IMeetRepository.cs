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
        public  Task<IList<Meet>> AddMeet(MeetDTO meetDTO);
        public  Task<IList<Meet>> DeleteMeet(int meetId);
        public  Task<IList<Meet>> GetMeetsList();

    }
}
