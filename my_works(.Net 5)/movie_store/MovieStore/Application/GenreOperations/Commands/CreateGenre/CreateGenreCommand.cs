using System.Linq;
using MovieStore.DBOperations;
using MovieStore.Entities;
using AutoMapper;
using System;

namespace MovieStore.Application.GenreOperations.Commands.CreateGenre{

    public class CreateGenreCommand{
        public CreateGenreModel newModel{get;set;}
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateGenreCommand(IMovieStoreDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(genre => genre.Name == newModel.Name);
            if(genre is not null)
                throw new InvalidOperationException("Genre name already exist!");

            genre = _mapper.Map<Genre>(newModel);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel{
        public string Name { get; set; }
    }
}