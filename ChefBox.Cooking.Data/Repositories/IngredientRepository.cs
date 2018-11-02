using ChefBox.Cooking.Data.Base;
using ChefBox.Cooking.Dto.Ingredient;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.Model.Cooking;
using ChefBox.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefBox.Cooking.Data.Repositories
{
    public class IngredientRepository : ChefBoxRepository, IIngredientRepository
    {

        public IngredientRepository(ChefBoxDbContext context) : base(context)
        {
        }

        public IEnumerable<IngredientDto> GetIngredients(string query)
        {
            return Context.Ingredients
                .Where(ing =>
                        ing.IsValid
                        &&
                        (
                            string.IsNullOrEmpty(query)
                            ||
                            ing.Name.ToUpper().Contains(query.ToUpper())
                        )
                    )
                    .Select(ing => new IngredientDto()
                    {
                        Id = ing.Id,
                        Name = ing.Name,
                        Description = ing.Description,
                        RecipesCount = ing.RecipeIngredients.Count(recIng => recIng.IsValid)
                    })
                    .ToList();
        }

        public IngredientDto ActionIngredient(IngredientDto ingredientDto)
        {
            try
            {
                Ingredient ingredientEntity = Context.Ingredients
               .SingleOrDefault(ing =>
                                   ing.IsValid
                                   &&
                                   ing.Id == ingredientDto.Id);
                EntityState entityState = EntityState.Modified;
                if (ingredientEntity == null)
                {
                    //Add case
                    ingredientEntity = new Ingredient()
                    {
                        Name = ingredientDto.Name,
                        Description = ingredientDto.Description
                    };
                    entityState = EntityState.Added;
                }
                else
                {
                    ingredientEntity.Name = ingredientEntity.Name;
                    ingredientEntity.Description = ingredientEntity.Description;
                }
                Context.Entry(ingredientEntity).State = entityState;
                Context.SaveChanges();
                ingredientDto.Id = ingredientEntity.Id;
                return ingredientDto;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool RemoveIngredient(int id)
        {
            try
            {
                var ingredientEntity = Context.Ingredients
                    .SingleOrDefault(ing => ing.IsValid && ing.Id == id);
                if (ingredientEntity != null)
                {
                    ingredientEntity.IsValid = false;
                    Context.Update(ingredientEntity);
                    Context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
