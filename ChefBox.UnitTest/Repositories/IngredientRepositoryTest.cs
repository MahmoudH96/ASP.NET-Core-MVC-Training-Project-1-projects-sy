using ChefBox.Cooking.Data.Repositories;
using ChefBox.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ChefBox.UnitTest.Repositories
{
    public class IngredientRepositoryTest
    {

        public int FirstIngredientId => 100;
        public string FirstIngredientName => "Ing 1";
        public ChefBoxDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ChefBoxDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;
            return new ChefBoxDbContext(options);
        }

        public void SeedIngredients(ChefBoxDbContext context)
        {
            context.Ingredients.Add(new Model.Cooking.Ingredient()
            {
                Id = FirstIngredientId,
                Name = FirstIngredientName
            });
            context.SaveChanges();
        }


        [Theory(DisplayName = "Get all ingredient")]
        [InlineData(null)]
        [InlineData("1")]
        public void GetAllIngredient(string query)
        {
            var context = GetDbContext();
            SeedIngredients(context);
            var ingredientRepo = new IngredientRepository(context);
            Assert.Single(ingredientRepo.GetIngredients(query));
        }

        [Fact(DisplayName = "Add new ingredient")]
        public void AddIngredient()
        {
            var ingredientRepo = new IngredientRepository(GetDbContext());
            var result = ingredientRepo.ActionIngredient(new Cooking.Dto.Ingredient.IngredientDto()
            {
                Name = "new ingredient",
                Description = "Test description"
            });
            Assert.NotEqual(0, result.Id);
        }

        [Fact(DisplayName = "Edit ingredient")]
        public void EditIngredient()
        {
            var ingredientRepo = new IngredientRepository(GetDbContext());
            var editName = "Ing 2";
            var editableData = ingredientRepo.ActionIngredient(new Cooking.Dto.Ingredient.IngredientDto()
            {
                Id = FirstIngredientId,
                Name = editName,
            });
            Assert.Equal(editName, editableData.Name);
            Assert.NotEqual(FirstIngredientName, editableData.Name);
        }

        [Fact(DisplayName = "Remove ingredient")]
        public void RemoveIngredient()
        {
            var context = GetDbContext();
            SeedIngredients(context);
            var ingredientRepo = new IngredientRepository(context);
            ingredientRepo.RemoveIngredient(FirstIngredientId);
            Assert.Empty(ingredientRepo.GetIngredients(null));
        }
    }
}
