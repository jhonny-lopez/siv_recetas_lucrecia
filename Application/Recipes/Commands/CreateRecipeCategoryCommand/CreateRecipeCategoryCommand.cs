using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Recipes.Commands.CreateRecipeCategoryCommand
{
    public class CreateRecipeCategoryCommand : IRequest
    {
        public CreateRecipeCategoryModel Model { get; set; }
    }
}
