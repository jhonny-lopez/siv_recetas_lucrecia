namespace Application.Ingredients.Commands.UpdateIngredient
{
    public interface IUpdateIngredientCommand
    {
        void Execute(UpdateIngredientModel model);
    }
}