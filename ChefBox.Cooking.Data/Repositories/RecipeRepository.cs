using ChefBox.Cooking.Data.Base;
using ChefBox.Cooking.Dto.Recipe;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChefBox.Cooking.Data.Repositories
{
    public class RecipeRepository : ChefBoxRepository, IRecipeRepository
    {
        public RecipeRepository(ChefBoxDbContext context) : base(context)
        {
        }


        public IList<RecipeIngredientDto> GetRecipeAllIngredients(int recipeId)
        {
            var joinTableIngredients = Context.RecipeIngredients
                .Where(ri =>
                    ri.RecipeId == recipeId
                    &&
                    ri.IsValid)
                    .Select(ri => new RecipeIngredientDto()
                    {
                        Id = ri.Id,
                        IngredientId = ri.IngredientId,
                        Amount = ri.Amount,
                        Name = ri.Ingredient.Name,
                        Unit = ri.Unit,
                        IsChecked = true
                    }).ToList();
            var joinTableIngredientsIds = joinTableIngredients.
                Select(ingDto => ingDto.Id)
                .ToList();
            var remainingIngredients = Context.Ingredients
                .Where(ing => !joinTableIngredientsIds.Contains(ing.Id))
                .Select(ing => new RecipeIngredientDto()
                {
                    IngredientId = ing.Id,
                    IsChecked = false
                }).ToList();
            return joinTableIngredients.Concat(remainingIngredients).ToList();
        }
        public RecipeFormDto ActionRecipeForm(RecipeFormDto recipeFormDto)
        {
            try
            {
                EntityState entityState = EntityState.Modified;
                var recipeEntity = Context.Recipes
                    .Where(rep => rep.IsValid && rep.Id == recipeFormDto.Id)
                    .Include(rep => rep.Photo)
                    .SingleOrDefault();
                if (recipeEntity == null)
                {
                    //Add case
                    recipeEntity = new Model.Cooking.Recipe()
                    {
                        Name = recipeFormDto.Name,
                        CategoryId = recipeFormDto.CategoryId,
                        RecipeType = recipeFormDto.RecipeType,
                        Descripton = recipeFormDto.Description,
                        IsPublished = recipeFormDto.IsPublished,
                        Photo = recipeFormDto.Photos?.Select(photoDto => new Model.Cooking.Photo()
                        {
                            Name = photoDto.Name,
                            Url = photoDto.Url,

                        }).ToList(),
                        RecipeIngredients = recipeFormDto.RecipeIngredients?
                        .Where(ri => ri.IsChecked)
                        .Select(riDto => new Model.Cooking.RecipeIngredient()
                        {
                            IngredientId = riDto.IngredientId,
                            Amount = riDto.Amount,
                            Unit = riDto.Unit
                        }).ToList()
                    };
                    Context.Recipes.Add(recipeEntity);
                }
                else
                {
                    //Edit case
                    recipeEntity.Name = recipeFormDto.Name;
                    recipeEntity.CategoryId = recipeFormDto.CategoryId;
                    recipeEntity.RecipeType = recipeFormDto.RecipeType;
                    recipeEntity.Descripton = recipeFormDto.Description;
                    recipeEntity.IsPublished = recipeFormDto.IsPublished;

                    RemoveRecipeIngredients(recipeEntity.Id);
                    recipeEntity.RecipeIngredients = recipeFormDto
                        .RecipeIngredients
                        .Where(riDto => riDto.IsChecked)
                        .Select(riDto => new Model.Cooking.RecipeIngredient()
                        {
                            IngredientId = riDto.IngredientId,
                            Amount = riDto.Amount,
                            Unit = riDto.Unit
                        }).ToList();

                    foreach (var photoDto in recipeFormDto.Photos)
                    {
                        recipeEntity.Photo.Add(new Model.Cooking.Photo()
                        {
                            Name = photoDto.Name,
                            Url = photoDto.Url
                        });
                    }
                    Context.Recipes.Update(recipeEntity);
                }
                Context.SaveChanges();
                recipeFormDto.Id = recipeEntity.Id;
                return recipeFormDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool RemoveRecipeIngredients(int recipeId)
        {
            try
            {
                var recipeIngredients = Context.RecipeIngredients
                    .Where(ri => ri.RecipeId == recipeId)
                    .ToList();
                Context.RecipeIngredients.RemoveRange(recipeIngredients);
                Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<RecipeDto> GetRecipes()
        {
            return Context.Recipes
                    .Where(recipe => recipe.IsValid)
                    .OrderBy(recipe => recipe.Name)
                    .Select(recipe => new RecipeDto()
                    {
                        Id = recipe.Id,
                        Name = recipe.Name,
                        RecipeType = recipe.RecipeType,
                        Category = recipe.Category.Name,
                        Ingredients = recipe.RecipeIngredients
                            .Select(ri => ri.Ingredient.Name)
                            .ToList()
                    }).ToList();
        }

        public ViewRecipeDto GetRecipe(int id)
        {
            return Context.Recipes
                .Where(recipe => recipe.IsValid && recipe.Id == id)
                .Select(recipe => new ViewRecipeDto()
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Category = recipe.Category.Name,
                    CategoryId = recipe.CategoryId,
                    RecipeType = recipe.RecipeType,
                    IsPublished = recipe.IsPublished,
                    Description = recipe.Descripton,
                    Ingredients = recipe.RecipeIngredients.Select(ri => new RecipeIngredientDto()
                    {
                        Id = ri.Id,
                        IngredientId = ri.IngredientId,
                        Amount = ri.Amount,
                        Name = ri.Ingredient.Name,
                        Unit = ri.Unit
                    }).ToList(),
                    Photos = recipe.Photo.Select(photo => new Dto.Photo.PhotoDto()
                    {
                        Id = photo.Id,
                        Name = photo.Name,
                        Url = photo.Url
                    }).ToList()
                }).SingleOrDefault();
        }
    }
}
