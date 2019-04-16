using System;
using System.ComponentModel.DataAnnotations;
using wawishapp.Models.Behavior;

namespace wawishapp.Models
{
    public class Customer : IAssign<Customer>
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

        public void AssignMe(Customer entity)
        {
            if (this == null) return;

            this.Name = entity.Name;
            this.Birthdate = entity.Birthdate;
            this.IsSubscribedToNewsletter = entity.IsSubscribedToNewsletter;
            this.MembershipType = this.MembershipType;
            this.MembershipTypeId = this.MembershipTypeId;
        }
    }
}