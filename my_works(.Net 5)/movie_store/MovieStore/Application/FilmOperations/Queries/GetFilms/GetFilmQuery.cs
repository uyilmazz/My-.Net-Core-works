using System;
using System.Linq;
using AutoMapper;
using MovieStore.DBOperations;
using MovieStore.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MovieStore.Application.FilmOperations.Queries.GetFilms
{

    public class GetFilmQuery
    {

        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetFilmQuery(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetFilmsViewModel> Handle()
        {
            var films = _context.Films.Include(x => x.Genre).Include(x => x.Director).OrderBy(x => x.Id).ToList();
            List<GetFilmsViewModel> vm = _mapper.Map<List<GetFilmsViewModel>>(films);
            return vm;
        }
    }

    public class GetFilmsViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public double Price { get; set; }
    }
}