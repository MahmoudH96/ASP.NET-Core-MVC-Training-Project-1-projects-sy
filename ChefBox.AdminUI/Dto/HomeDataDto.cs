using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefBox.AdminUI.Dto
{
    public class HomeDataDto
    {
        public int RecipesCount { get; set; }
        public int IngredientsCount { get; set; }
        public int CategoriesCount { get; set; }
        public string TipOfTheDay { get; set; }
    }
}
