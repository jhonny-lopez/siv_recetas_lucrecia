using System.Threading.Tasks;

namespace Application.Recipes.Queries.GetRecipeDetailsQuery
{
    public interface IGetRecipeDetailsQuery
    {
        Task<GetRecipeDetailsModel> ExecuteAsync(int recipeId);
    }
}