
using AutoMapper;
using MovieStore.Application.FilmOperations.Queries.GetFilms;
using MovieStore.Application.GenreOperations.Queries.GetGenres;
using MovieStore.Entities;
using MovieStore.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStore.Application.FilmOperations.Commands.CreateFilm;
using MovieStore.Application.GenreOperations.Commands.CreateGenre;
using MovieStore.Application.GenreOperations.Commands.UpdateGenre;

namespace MovieStore.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Film, GetFilmsViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.Name));
            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
            CreateMap<CreateFilmCommandModel,Film>();
            CreateMap<CreateGenreModel,Genre>();
            CreateMap<UpdateGenreModel, Genre>();
        }
    }
}