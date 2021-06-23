namespace Application.Recipes.Queries.GetFilteredRecipesList
{
    public interface IGetFilteredRecipesListQuery
    {
        GetFilteredRecipesListModel Execute(RecipesFiltersModel filters);
    }
}