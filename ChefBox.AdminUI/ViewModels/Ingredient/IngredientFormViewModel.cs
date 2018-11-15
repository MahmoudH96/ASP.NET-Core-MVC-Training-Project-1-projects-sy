using ChefBox.AdminUI.ViewModels.Base;
using System.ComponentModel.DataAnnotations;

namespace ChefBox.AdminUI.ViewModels.Ingredient
{
    public class IngredientFormViewModel : ChefBoxViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the ingredient name")]
        public string Name { get; set; }
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Description should be between 5 and 250 characters")]
        public string Description { get; set; }
    }
}
