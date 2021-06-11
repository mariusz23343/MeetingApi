using MeetingApi.Models.DbModels.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Models.DbModels
{
    public class Meet
    {
        public Meet()
        {
            this.Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Wrong Meet Name Length")]
        public string MeetName { get; set; }
        
        [Required]
        public DateTime MeetDate { get; set; }

        
        public virtual ICollection<Participant> Participants { get; set; }
    }

    //public class MeetDateInFuture : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        var meetDTO = (MeetDTO)validationContext.ObjectInstance;
    //        if (meetDTO.MeetDate <= DateTime.Today)
    //            return new ValidationResult("Meet date has to be in the future");
    //        return ValidationResult.Success;


    //    }
    //}
}
