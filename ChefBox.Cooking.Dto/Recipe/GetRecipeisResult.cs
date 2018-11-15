using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.Dto.Recipe
{
   public  class RecipeisResult
    {
        public int TotalResultCount { get; set; }
        public IEnumerable<RecipeDto> PageData { get; set; }
    }
}
