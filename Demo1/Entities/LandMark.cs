using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Entities {
    public class LandMark {
        public LandMark(string name) {
            Name = name;
        }

        [Key]
        public int Id { get; set; }
     
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string? Description { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public bool IsNice { get; set; }
    }
}
