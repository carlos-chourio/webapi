using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs {
    public class BookDtoBase {
        [Required]
        public string Name { get;set; }
        [Required]
        public string Description { get;set; }
        [Required]
        public string Author { get;set; }
    }
}