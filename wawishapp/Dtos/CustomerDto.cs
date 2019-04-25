using System;
using System.ComponentModel.DataAnnotations;
using wawishapp.Models;

namespace wawishapp.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        
        [Required(ErrorMessage = "Please select a membership type")]
        public byte? MembershipTypeId { get; set; }
    }
}