using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs {
    public class BookDtoBase {
        [Required]
        public string Title { get;set; }
        [Required]
        public string Description { get;set; }
    }
}