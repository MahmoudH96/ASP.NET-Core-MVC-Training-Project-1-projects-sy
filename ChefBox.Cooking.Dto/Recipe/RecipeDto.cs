using ChefBox.Model.Cooking.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.Dto.Recipe
{
    public class RecipeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RecipeType RecipeType { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<string> Ingredients { get; set; }
    }
}
