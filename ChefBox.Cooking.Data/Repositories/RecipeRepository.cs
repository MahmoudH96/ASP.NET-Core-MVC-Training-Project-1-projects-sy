using ChefBox.Cooking.Data.Base;
using ChefBox.Cooking.Dto.Recipe;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ChefBox.Cooking.Data.Repositories
{
    public class RecipeRepository : ChefBoxRepository, IRecipeRepository
    {
        public RecipeRepository(ChefBoxDbContext context) : base(context)
        {
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
                        Photo = recipeFormDto.Photos.Select(photoDto => new Model.Cooking.Photo()
                        {
                            Name = photoDto.Name,
                            Url = photoDto.Url,

                        }).ToList(),
                        RecipeIngredients = recipeFormDto.RecipeIngredients.Select(riDto => new Model.Cooking.RecipeIngredient()
                        {
                            IngredientId = riDto.Id,
                            Amount = riDto.Amount,
                            Unit = riDto.Unit
                        }).ToList()
                    };
                    entityState = EntityState.Added;
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
                        .RecipeIngredients.Select(riDto => new Model.Cooking.RecipeIngredient()
                        {
                            IngredientId = riDto.Id,
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
                }

                Context.Entry(recipeEntity).State = entityState;
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
    }
}
