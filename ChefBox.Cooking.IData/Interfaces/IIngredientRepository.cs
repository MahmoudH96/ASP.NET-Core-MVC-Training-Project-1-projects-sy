using ChefBox.Cooking.Dto.Ingredient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.IData.Interfaces
{
    public interface IIngredientRepository
    {
        IEnumerable<IngredientDto> GetIngredients(string query);
        IngredientDto GetIngredient(int id);
        IngredientDto ActionIngredient(IngredientDto ingredientDto);
        bool RemoveIngredient(int id);
    }
}
