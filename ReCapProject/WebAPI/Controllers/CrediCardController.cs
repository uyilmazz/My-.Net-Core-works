using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrediCardController : ControllerBase
    {
        private readonly ICrediCardService _crediCardService;

        public CrediCardController(ICrediCardService crediCardService)
        {
            _crediCardService = crediCardService;
        }

        [HttpGet]
        public IActionResult GetCrediCard(int id)
        {
            var result = _crediCardService.GetCrediCardDto(id);
            if (result.Success) {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("addMoney")]
        public IActionResult AddMoney(int crediCardId,int money)
        {
            var result = _crediCardService.AddMoney(crediCardId, money);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("draftMoney")]
        public IActionResult DraftMoney(int crediCardId, int money)
        {
            var result = _crediCardService.DraftMoney(crediCardId, money);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
