namespace Application.Ingredients.Commands.CreateIngredient
{
    public interface ICreateIngredientCommand
    {
        void Execute(CreateIngredientModel model);
    }
}