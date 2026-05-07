using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Entities {
    public class City {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public int Population { get; set; }

        public string Country { get; set; }

        public City(string name) {
            Name = name;
        }

        public ICollection<LandMark> LandMarks { get; set; } = new List<LandMark>();
    }
}
