using System.ComponentModel.DataAnnotations;

namespace DoddingtonCarnival.Blazor.Models
{
    public class StallHolder
    {
        [Required]
        [Display(Name = "stall name")]
        public string StallName { get; set; }

        [Required]
        [Display(Name = "contact name")]
        public string ContactName { get; set; }
        
        public Address Address { get; set; } = new();

        [Required]
        [Display(Name = "mobile number")]
        public string MobileNumber { get; set; }
        
        [Required]
        [Display(Name = "email address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter a valid email address, as this doesn't look right.")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "nature of your stall")]
        public string NatureOfStall { get; set; }

        public int StallFee { get; set; }
    }
}
