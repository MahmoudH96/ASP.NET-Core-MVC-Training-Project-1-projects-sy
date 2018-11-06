using ChefBox.AdminUI.ViewModels.Base;
using ChefBox.Cooking.Dto.Recipe;
using System.Collections.Generic;

namespace ChefBox.AdminUI.ViewModels.Recipe
{
    public class IndexViewModel: ChefBoxViewModel
    {
        public IEnumerable<RecipeDto> Recipes { get; set; }
    }
}
