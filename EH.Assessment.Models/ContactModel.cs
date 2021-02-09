using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EH.Assessment.Models
{
    public class ContactModel
    {
        public Guid ContactId { get; set; }

        [Display(Name = "First Name")]

        [Required(ErrorMessage = "First Name can not be blank")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name should have characters only")]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name can not be blank")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name should have characters only")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email can not be blank")]
        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Phone")]

        [RegularExpression(@"(?:\s+|)((0|(?:(\+|)91))(?:\s|-)*(?:(?:\d(?:\s|-)*\d{9})|(?:\d{2}(?:\s|-)*\d{8})|(?:\d{3}(?:\s|-)*\d{7}))|\d{10})(?:\s+|)", ErrorMessage = "Phone number is not valid")]
        [Required(ErrorMessage = "Phone number can not be blank")]
        public string Phone { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
        public int ContactTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public string Mode { get; set; }
    }
}
