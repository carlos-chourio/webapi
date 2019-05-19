using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities {
    [Table("Author", Schema = "api")]
    public class Author {
        public int Id { get;set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get;set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get;set; }
        [Required]
        public DateTime Birthday { get;set; }
        public DateTime? DateOfDeath { get;set; }
    }
}