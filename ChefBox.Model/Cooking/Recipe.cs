using ChefBox.Model.Base;
using ChefBox.Model.Cooking.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefBox.Model.Cooking
{
    [Table("Recipes", Schema = "Cooking")]
    public class Recipe : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string Descripton { get; set; }
        public RecipeType RecipeType { get; set; }
        public string Note { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Photo> Photo { get; set; }
        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
