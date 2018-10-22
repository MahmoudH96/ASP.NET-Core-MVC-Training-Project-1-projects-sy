using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkInDepth.Models
{
    /// <summary>
    /// Customizing entity using data attributes
    /// </summary>
    [Table("CarTable", Schema = "Vechiles")]
    public class Car
    {
        [Key]
        public int TheCarKey { get; set; }
        [Column(name: "CarName")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Model { get; set; }
        [StringLength(maximumLength: 1000, MinimumLength = 100)]
        public string Description { get; set; }
        [NotMapped]
        public double Price { get; set; }
    }
}
