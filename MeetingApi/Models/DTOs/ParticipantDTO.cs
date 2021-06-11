using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Models.DTOs
{
    public class ParticipantDTO
    {
        public string ParticipantName { get; set; }
        public string Email { get; set; }
        public int MeetId { get; set; }
    }
}
