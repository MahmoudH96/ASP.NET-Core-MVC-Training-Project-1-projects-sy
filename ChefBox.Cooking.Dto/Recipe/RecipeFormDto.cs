using ChefBox.Cooking.Dto.Photo;
using ChefBox.Model.Cooking.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.Dto.Recipe
{
    public class RecipeFormDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public RecipeType RecipeType { get; set; }
        public string Description { get; set; }
        public IEnumerable<RecipeIngredientDto> RecipeIngredients { get; set; }
        public IEnumerable<PhotoDto> Photos { get; set; }
        public bool IsPublished { get; set; }
    }
}
