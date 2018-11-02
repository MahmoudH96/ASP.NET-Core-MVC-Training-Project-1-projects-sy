using ChefBox.Cooking.Dto.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChefBox.Cooking.IData.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetCategories();
    }
}
