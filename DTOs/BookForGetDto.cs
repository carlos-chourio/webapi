using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs {
    public class BookForGetDto : BookDtoBase {
        [Required]
        public string Author { get; set; }
    }
}
