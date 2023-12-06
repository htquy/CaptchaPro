using System.ComponentModel.DataAnnotations;

namespace Captcha.Datas
{
    public class TT
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [MaxLength(10)]
        public string Sexual { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
