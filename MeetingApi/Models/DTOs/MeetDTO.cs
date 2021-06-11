using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Models.DbModels.DTOs
{
    public class MeetDTO
    {
        public string MeetName { get; set; }

        public DateTime MeetDate { get; set; }
    }
}
