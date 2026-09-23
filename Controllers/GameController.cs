using System.Reflection.Metadata.Ecma335;
using Challenge_4_Video_Game_CRUD_API.Models;
using Challenge_4_Video_Game_CRUD_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge_4_Video_Game_CRUD_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        
     private readonly IGameServices _inventory;

public GameController(IGameServices inventory)
        {
            _inventory = inventory;
        }


        [HttpGet("GetAll")]

        public ActionResult GetAllGames()
        {
            return Ok(_inventory.GetAll());
        }


        [HttpGet("GetByGenre/{genre}")]

        public ActionResult<List<GameItem>> GetByGenre(string genre)
        {
            List<GameItem> items = _inventory.GetByGenre(genre);

            return Ok(items);
        }

      [HttpGet("GetbyId/{id}")]

      public ActionResult<GameItem> GetById(int id)
        {
            GameItem item = _inventory.GetById(id);

            if (item == null)
            {
                return NotFound($"No game found for id {id}");
            }

            return Ok(item);
        }


        [HttpGet("GetByAvailable")]

        public ActionResult<GameItem> GetByAvailable(string name)
        {
            bool gameIsAvailable = _inventory.GetByIsAvailable;
            {
                if(gameIsAvailable == false)
                {
                    return NotFound($"Sorry the game {name} is not available");
                }

                return Ok(gameIsAvailable);

            }
        }

        [HttpPost("Create")]

        public ActionResult<GameItem> Create([FromBody] GameItem item)
        {
            GameItem newItem = _inventory.Create(item);

            return CreatedAtAction(
                nameof(GetById),
                new { id = newItem.Id},
                newItem
            );
        }

        [HttpPut("Update/{id}")]

        public ActionResult<bool> UpdateGame(int id, GameItem item)
        {
            bool updated = _inventory.Update(id, item);

            if(updated == false)
            {
                return NotFound($"No game was found with Id {id}");
            }

            return NoContent();
        }


        [HttpDelete("Delete/{id}")]

        public ActionResult<bool> DeleteGame(int id)
        {
            bool deleted = _inventory.Delete(id);

            if(deleted == false)
            {
                return NotFound($"No game with Id {id} found");
            }

            return Ok(deleted);
        }


    }
}