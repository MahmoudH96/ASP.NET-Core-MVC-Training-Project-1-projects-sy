using ChefBox.Cooking.Dto.Category;
using ChefBox.Cooking.Dto.Recipe;
using ChefBox.Model.Cooking.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChefBox.AdminUI.ViewModels.Recipe
{
    public class RecipeFormViewModel
    {
        #region Form Data
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name ="Category")]
        public int CategoryId { get; set; }
        public RecipeType RecipeType { get; set; }
        public string Description { get; set; }
        public IEnumerable<RecipeIngredientDto> RecipeIngredients { get; set; }
        [Display(Name = "Is published")]

        public bool IsPublished { get; set; }
        #endregion

        #region Lists
        public IEnumerable<SelectListItem> Categories { get; set; }
        #endregion
    }
}
