using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryProject.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="The Title is required")]
        [StringLength(50, ErrorMessage ="The {0} required minimum {2} characters and maximun {1}", MinimumLength = 3)]
        public string Title { get; set; }
        [Required(ErrorMessage = "The Description is required")]
        [StringLength(50, ErrorMessage = "The {0} required minimum {2} characters and maximun {1}", MinimumLength = 3)]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Date is required")]
[DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "The Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "The Price is required")]
        public int Price { get; set; }
    }
}
