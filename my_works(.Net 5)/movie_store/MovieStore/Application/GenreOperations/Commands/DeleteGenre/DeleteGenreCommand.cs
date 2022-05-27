using System.Linq;
using MovieStore.DBOperations;
using MovieStore.Entities;
using AutoMapper;
using System;

namespace MovieStore.Application.GenreOperations.Commands.DeleteGenre{

    public class DeleteGenreCommand{
        public int GenreId{get;set;}
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public DeleteGenreCommand(IMovieStoreDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException("Genre is not found!");
            
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}