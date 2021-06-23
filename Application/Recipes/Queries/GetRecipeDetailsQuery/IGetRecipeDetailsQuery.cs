namespace Application.Recipes.Queries.GetRecipeDetailsQuery
{
    public interface IGetRecipeDetailsQuery
    {
        GetRecipeDetailsModel Execute(int recipeId);
    }
}