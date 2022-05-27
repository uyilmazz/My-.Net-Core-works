using MovieStore.DBOperations;
using System.Linq;
using MovieStore.Entities;
using AutoMapper;
using System;

namespace MovieStore.Application.FilmOperations.Commands.CreateFilm{

    public class CreateFilmCommand{

        public CreateFilmCommandModel newModel{get;set;}
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        
        public CreateFilmCommand(IMovieStoreDBContext context,IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var film = _context.Films.SingleOrDefault(film => film.Name == newModel.Name);
            if(film is not null)
                throw new InvalidOperationException("Film name already exist!");

            film = _mapper.Map<Film>(newModel);
            _context.Films.Add(film);
        }
    }

    public class CreateFilmCommandModel{
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public double Price { get; set; }
    }
}