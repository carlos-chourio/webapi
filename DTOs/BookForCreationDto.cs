using System.ComponentModel.DataAnnotations;

namespace WebApi.DTOs {
    public class BookForCreationDto : BookDtoBase {
        [Required]
        public int AuthorId { get;set; }
    }
}