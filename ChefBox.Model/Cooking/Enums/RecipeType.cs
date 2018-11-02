using System.ComponentModel.DataAnnotations;

namespace ChefBox.Model.Cooking.Enums
{
    public enum RecipeType
    {
        Entrees,
        [Display(Name = "Main dish")]
        MainDish,
        Sweet,
        Others
    }
}
