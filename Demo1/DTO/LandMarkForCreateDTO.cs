using System.ComponentModel.DataAnnotations;

namespace Demo1.DTO {
    public class LandMarkForCreateDTO {
        [Required]
        [MinLength(5, ErrorMessage = "No way dude, you cant do that!")]
        //[Range()]
        public string? Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }
    }

    public class LandMarkForUpdateDTO {
        [Required]
        [MinLength(5, ErrorMessage = "No way dude, you cant do that!")]
        //[Range()]
        public string? Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }
    }
}
