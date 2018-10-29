using ChefBox.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChefBox.Model.Cooking
{
    [Table("Photos", Schema = "Cooking")]
    public class Photo : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Url { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
