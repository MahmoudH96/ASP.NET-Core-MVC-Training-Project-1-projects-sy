using ChefBox.Cooking.Dto.Recipe;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.IData.Interfaces
{
    public interface IRecipeRepository
    {
        RecipeFormDto ActionRecipeForm(RecipeFormDto recipeFormDto);
    }
}
