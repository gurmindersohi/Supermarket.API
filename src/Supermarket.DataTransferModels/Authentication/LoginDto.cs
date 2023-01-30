namespace Supermarket.DataTransferModels.Authentication
{
    using System.ComponentModel.DataAnnotations;
    public class LoginDto
	{
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }
    }
}

