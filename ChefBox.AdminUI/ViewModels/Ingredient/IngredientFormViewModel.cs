using ChefBox.AdminUI.ViewModels.Base;

namespace ChefBox.AdminUI.ViewModels.Ingredient
{
    public class IngredientFormViewModel: ChefBoxViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
