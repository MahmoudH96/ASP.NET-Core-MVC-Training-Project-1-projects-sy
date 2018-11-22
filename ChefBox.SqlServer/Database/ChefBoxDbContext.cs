using ChefBox.Model.Configuration;
using ChefBox.Model.Cooking;
using ChefBox.Model.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.SqlServer.Database
{
    public class ChefBoxDbContext : IdentityDbContext<CBUser, CBRole, int, CBUserClaim, CBUserRole
                                                     , CBUserLogin, CBRoleClaim, CBUserToken>
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public ChefBoxDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }
    }
}
