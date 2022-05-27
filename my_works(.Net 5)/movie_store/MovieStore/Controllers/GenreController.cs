using System;
using Microsoft.AspNetCore.Mvc;
using MovieStore.DBOperations;
using AutoMapper;
using MovieStore.Application.GenreOperations.Queries.GetGenres;
using MovieStore.Application.GenreOperations.Queries.GetGenreDetail;
using MovieStore.Application.GenreOperations.Commands.CreateGenre;
using MovieStore.Application.GenreOperations.Commands.UpdateGenre;
using FluentValidation;
using MovieStore.Application.GenreOperations.Commands.DeleteGenre;

namespace MovieStore.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult getGenres()
        {
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }

        [HttpGet("id")]
        public IActionResult getGenreDetail(int id){  
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();
            query.GenreId = id;
            validator.ValidateAndThrow(query);
            var result = query.Handle();
            return Ok(result);                 
        }

        [HttpPost]
        public IActionResult createGenre([FromBody] CreateGenreModel model){
            CreateGenreCommand command = new CreateGenreCommand(_context,_mapper);
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            command.newModel = model;

            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult updateGenre([FromBody] UpdateGenreModel model,int id){
            UpdateGenreCommand command = new UpdateGenreCommand(_context,_mapper);
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
            command.UpdateModel = model;
            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpDelete("id")]
        public IActionResult deleteGenre(int id){
            DeleteGenreCommand command = new DeleteGenreCommand(_context,_mapper);
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            command.GenreId = id;
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();            
        }
        
    }
}