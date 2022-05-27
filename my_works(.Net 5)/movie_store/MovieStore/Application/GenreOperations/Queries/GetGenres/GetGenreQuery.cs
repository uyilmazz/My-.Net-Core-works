using System;
using System.Linq;
using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MovieStore.Application.GenreOperations.Queries.GetGenres
{

    public class GetGenreQuery
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetGenreQuery(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.ToList();
            List<GenreViewModel> vm = _mapper.Map<List<GenreViewModel>>(genres);
            return vm;
        }
    }

    public class GenreViewModel
    {
        public string Name { get; set; }
    }
}