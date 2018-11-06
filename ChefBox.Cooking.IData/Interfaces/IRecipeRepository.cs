using ChefBox.Cooking.Dto.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.IData.Interfaces
{
    public interface IRecipeRepository
    {
        IEnumerable<RecipeDto> GetRecipes();
        ViewRecipeDto GetRecipe(int id);
        RecipeFormDto ActionRecipeForm(RecipeFormDto recipeFormDto);
        IList<RecipeIngredientDto> GetRecipeAllIngredients(int recipeId);
    }
}
