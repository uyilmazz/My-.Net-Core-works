using System;
using System.Linq;
using MovieStore.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Entities;

namespace MovieStore.Application.GenreOperations.Queries.GetGenreDetail{
    public class GetGenreDetailQuery{

        public int GenreId{get;set;}
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQuery(IMovieStoreDBContext context,IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle(){
            var genre = _context.Genres.SingleOrDefault(genre => genre.Id == GenreId);
            if(genre is null)
                throw new InvalidOperationException("There is not genre of film");

            GenreDetailViewModel _genre = _mapper.Map<GenreDetailViewModel>(genre);
            return _genre;
        }
    }
    
    public class GenreDetailViewModel{
        public string Name { get; set; }
    }
}