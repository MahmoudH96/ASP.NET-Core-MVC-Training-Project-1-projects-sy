﻿using ChefBox.AdminUI.ViewModels.Base;
using ChefBox.Cooking.Dto.Ingredient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefBox.AdminUI.ViewModels.Ingredient
{
    public class IndexViewModel: ChefBoxViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<IngredientDto> Ingredients { get; set; }
    }
}
