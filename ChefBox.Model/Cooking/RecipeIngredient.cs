using ChefBox.Model.Base;
using ChefBox.Model.Cooking.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChefBox.Model.Cooking
{
    [Table("RecipeIngredients", Schema = "Cooking")]
    public class RecipeIngredient : BaseEntity
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public Ingredient Ingredient { get; set; }
        public int IngredientId { get; set; }

        public double Amount { get; set; }
        public Unit Unit { get; set; }
    }
}
