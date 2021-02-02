using System.ComponentModel.DataAnnotations;

namespace Advertisement.API.Application.Models
{
    public class AddAdvertModels
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
