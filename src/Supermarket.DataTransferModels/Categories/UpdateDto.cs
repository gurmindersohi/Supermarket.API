namespace Supermarket.DataTransferModels.Categories
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UpdateDto
	{
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
    }
}

