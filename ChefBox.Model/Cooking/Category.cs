using ChefBox.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChefBox.Model.Cooking
{
    [Table("Categories", Schema = "Cooking")]
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
