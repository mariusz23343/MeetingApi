using MeetingApi.Models.DbModels;
using MeetingApi.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MeetingApi.Reposiories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AppDbContext _context;
        public ParticipantRepository(AppDbContext context)
        {
            _context = context;
        }
        

        public async Task <IList<Participant>> AddParticipantToMeet(ParticipantDTO participant)
        {
            IList<Participant> values = new List<Participant>();
            
            
                var tmp = new Participant
                {
                    ParticipantName = participant.ParticipantName,
                    Email = participant.Email,
                    FkMeet = participant.MeetId,
                    FkMeetName = _context.Meets.FirstOrDefault(x => x.Id == participant.MeetId)

                };

                await _context.AddAsync(tmp);
                await _context.SaveChangesAsync();
               

                
            
            values = await _context.Participants.Where(x => x.FkMeet == participant.MeetId).ToListAsync();

            return values;
        }

        public async Task<int> CheckParticipantsNumber(int id)
        {
            var numberOfElements = await _context.Participants.Where(p => p.FkMeet == id).CountAsync();
            return numberOfElements;
        }
        public async Task <bool> CheckIfMeetExist(int id)
        {
            return await _context.Meets.AnyAsync(x => x.Id == id);
        }
    }
}
