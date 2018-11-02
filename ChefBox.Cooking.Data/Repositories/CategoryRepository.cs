using ChefBox.Cooking.Data.Base;
using ChefBox.Cooking.Dto.Category;
using ChefBox.Cooking.IData.Interfaces;
using ChefBox.SqlServer.Database;
using System.Collections.Generic;
using System.Linq;

namespace ChefBox.Cooking.Data.Repositories
{
    public class CategoryRepository : ChefBoxRepository, ICategoryRepository
    {
        public CategoryRepository(ChefBoxDbContext context) : base(context)
        {
        }
        public IEnumerable<CategoryDto> GetCategories()
        {
            return Context.Categories.Where(cat => cat.IsValid)
                .OrderBy(cat => cat.Name)
                .Select(cat => new CategoryDto()
                {
                    Id = cat.Id,
                    Name = cat.Name
                }).ToList();
        }
    }
}
