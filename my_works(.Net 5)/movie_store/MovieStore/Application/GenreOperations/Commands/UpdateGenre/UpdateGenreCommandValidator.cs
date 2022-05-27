
using FluentValidation;

namespace MovieStore.Application.GenreOperations.Commands.UpdateGenre{

    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>{

        public UpdateGenreCommandValidator(){
            RuleFor(command => command.UpdateModel.Name).NotEmpty().MinimumLength(4);
            RuleFor(command => command.GenreId).GreaterThan(0);
        }
    } 
}