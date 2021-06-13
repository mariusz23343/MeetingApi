using MeetingApi.Models.DbModels;
using MeetingApi.Models.DbModels.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Reposiories
{
    public class MeetRepository : IMeetRepository
    {
        private readonly AppDbContext _context;
        public MeetRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IList<Meet>> AddMeet(MeetDTO meetDTO)
        {
            var meet = new Meet { MeetName = meetDTO.MeetName, MeetDate = meetDTO.MeetDate };
            await _context.Meets.AddAsync(meet);
            await _context.SaveChangesAsync();

            return await GetMeetsList();
        }

        public async Task <IList<Meet>> DeleteMeet(int meetId)
        {
            var tmp = await _context.Meets.FirstOrDefaultAsync(x => x.Id == meetId);
            if (tmp == null)
            {
                return null;
            }
            var meetParticipants =  _context.Participants.Where(p => p.FkMeet == meetId);

            if(meetParticipants != null)
            {
               foreach(var item in meetParticipants)
                {
                    _context.Participants.Remove(item);
                }
                _context.SaveChanges();
            }
                

            _context.Meets.Remove(tmp);
            
            await _context.SaveChangesAsync();

            return await GetMeetsList();

        }

        public async Task <IList<Meet>> GetMeetsList()
        {
            return await _context.Meets.ToListAsync();
        }
       
        
    }
}
