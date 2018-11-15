using ChefBox.AdminUI.ViewModels.Base;
using ChefBox.Cooking.Dto.Category;
using ChefBox.Cooking.Dto.Recipe;
using ChefBox.Model.Cooking.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace ChefBox.AdminUI.ViewModels.Recipe
{
    public class IndexViewModel: ChefBoxViewModel
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<RecipeDto> SinglePageData { get; set; }
        public IPagedList<RecipeDto> PageListData { get; set; }

        public string Query { get; set; }
        public int? CategoryId { get; set; }
        public RecipeType? RecipeType { get; set; }
    }
}
