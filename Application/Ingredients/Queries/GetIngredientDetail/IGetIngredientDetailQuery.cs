namespace Application.Ingredients.Queries.GetIngredientDetail
{
    public interface IGetIngredientDetailQuery
    {
        IngredientModel Execute(int id);
    }
}