using System;
using System.ComponentModel.DataAnnotations;
using wawishapp.Models.Behavior;

namespace wawishapp.Models
{
    public class Customer : IAssign<Customer>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please select a membership type")]
        public byte? MembershipTypeId { get; set; }

        public void AssignMe(Customer entity)
        {
            if (this == null) return;

            this.Name = entity.Name;
            this.Birthdate = entity.Birthdate;
            this.IsSubscribedToNewsletter = entity.IsSubscribedToNewsletter;
            this.MembershipTypeId = entity.MembershipTypeId;
        }
    }
}