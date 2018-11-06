using ChefBox.Cooking.Dto.Ingredient;
using ChefBox.Cooking.Dto.Photo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.Dto.Recipe
{
    public class ViewRecipeDto:RecipeDto
    {
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public IEnumerable<PhotoDto> Photos { get; set; }
        public new IEnumerable<RecipeIngredientDto> Ingredients { get; set; }

    }
}
