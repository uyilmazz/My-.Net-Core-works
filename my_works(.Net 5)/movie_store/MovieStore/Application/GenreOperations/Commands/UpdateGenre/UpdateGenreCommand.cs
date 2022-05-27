using System.Linq;
using MovieStore.DBOperations;
using MovieStore.Entities;
using AutoMapper;
using System;

namespace MovieStore.Application.GenreOperations.Commands.UpdateGenre{


    public class UpdateGenreCommand{
        public int GenreId{get;set;}
        public UpdateGenreModel UpdateModel{get;set;}
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public UpdateGenreCommand(IMovieStoreDBContext context,IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException("Genre is not found!");
            if(_context.Genres.Any(genre => genre.Name == UpdateModel.Name))
                throw new InvalidOperationException("Genre name already exist!");
            
           genre.Name = String.IsNullOrEmpty(UpdateModel.Name) ?  genre.Name : UpdateModel.Name;
           _context.SaveChanges();
        }
        
    }
    public class UpdateGenreModel{
        public string Name { get; set; }
    }
}