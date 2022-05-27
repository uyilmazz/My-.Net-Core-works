using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieStore.DBOperations;
using AutoMapper;
using MovieStore.Application.FilmOperations.Queries.GetFilms;
using MovieStore.Application.FilmOperations.Commands.CreateFilm;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class FilmController : ControllerBase
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public FilmController(MovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getFilms()
        {
            GetFilmQuery query = new GetFilmQuery(_context, _mapper);
            var response = query.Handle();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult createFilm([FromBody] CreateFilmCommandModel model){
            CreateFilmCommand command = new CreateFilmCommand(_context,_mapper);
            command.newModel = model;
            command.Handle();
            return Ok();
        }
    }
}