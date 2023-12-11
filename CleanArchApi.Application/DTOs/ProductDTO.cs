using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.DTOs
{
    public record ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The preice is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The stock is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "The image is required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Image")]
        public string Image { get; set; }
        
        [DisplayName("Categories")]
        public int CategoryId { get; set; }
    }
}
