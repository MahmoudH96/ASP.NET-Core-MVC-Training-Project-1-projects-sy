using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.Dto.Shared
{
    public class HomePageDto
    {
        public CardDto Categories { get; set; }
        public CardDto Ingredients { get; set; }
        public CardDto Recipes { get; set; }
    }
}
