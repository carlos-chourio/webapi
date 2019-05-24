using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities {
    [Table("Book",Schema = "api")]
    public class Book {
        public int Id { get;set; }
        [Required]
        [MaxLength(300)]
        public string Title { get;set; }
        [Required]
        [MaxLength(600)]
        public string Description { get;set; }
        [Required]
        public int AuthorId { get;set; }
        public Author Author { get;set; }
    }
    
}