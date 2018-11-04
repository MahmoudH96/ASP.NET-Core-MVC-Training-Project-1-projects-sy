using ChefBox.Model.Cooking.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.Dto.Recipe
{
    public class RecipeIngredientDto
    {
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public Unit Unit { get; set; }
        public double Amount { get; set; }
        public bool IsChecked { get; set; }
    }
}
