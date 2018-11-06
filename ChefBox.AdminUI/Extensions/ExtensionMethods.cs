using ChefBox.Model.Cooking.Enums;

namespace ChefBox.AdminUI.Extensions
{
    public static class ExtensionMethods
    {
        public static string ToIconClass(this Unit unit)
        {
            switch (unit)
            {
                case Unit.M:
                case Unit.Inch:
                case Unit.Length:
                case Unit.MM:
                case Unit.CM:
                    {
                        return "fas fa-ruler-vertical";
                    }
                case Unit.cup:
                case Unit.Ounce:
                    {
                        return "mdi mdi-cup";
                    }
                case Unit.Tablespoon:
                case Unit.Teaspoon:
                    {
                        return "fas fa-utensil-spoon";
                    }
                case Unit.Kg:
                case Unit.G:
                case Unit.Pound:
                    {
                        return "fas fa-weight-hanging";
                    }
                default:
                    {
                        return "fas fa-shapes";
                    }
            }
        }
        public static string ToIconClass(RecipeType recipeType)
        {
            switch (recipeType)
            {
                case RecipeType.Entrees:
                    {
                        return "fas fa-utensils";
                    }
                case RecipeType.MainDish:
                    {
                        return "mdi mdi-food";
                    }
                case RecipeType.Sweet:
                    {
                        return "fas fa-cookie";
                    }
                default:
                    {
                        return "mdi-food-variant";
                    }
            }
        }
    }
}
