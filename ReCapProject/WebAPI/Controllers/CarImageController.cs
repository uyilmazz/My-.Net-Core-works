using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImageController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("carId")]
        public IActionResult GetAllByCarId(int id)
        {
            var result = _carImageService.GetCarImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult CreateCarImage([FromForm] IFormFile file, [FromForm] int carId)
        {
            var result = _carImageService.Add(file, carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateCarImage([FromForm] IFormFile file,[FromForm] int id)
        {
            var result = _carImageService.Update(file, id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult DeleteCarImage(int id)
        {
            
            var result = _carImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
