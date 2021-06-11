using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Models.DbModels
{
    public class Participant
    {
        [Required]
        public int Id { get; set; }
        
       
        public string ParticipantName { get; set; }
      
    
        public string Email { get; set; }

        public int FkMeet { get; set; }
        public virtual Meet FkMeetName { get; set; }
    }
}
