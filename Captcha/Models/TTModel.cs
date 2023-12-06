using System.ComponentModel.DataAnnotations;

namespace Captcha.Models
{
    public class TTModel
    {
        [Required] 
        public string Fullname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Sexual { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
