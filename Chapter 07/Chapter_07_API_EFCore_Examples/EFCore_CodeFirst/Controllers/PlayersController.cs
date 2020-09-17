using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFCore_CodeFirst.Db;
using EFCore_CodeFirst.Dto.Players;
using EFCore_CodeFirst.Db.Models;
using EFCore_CodeFirst.Interfaces;
using EFCore_CodeFirst.Dto;

namespace EFCore_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayersAsync([FromQuery] UrlQueryParameters urlQueryParameters)
        {
            var player = await _playerService.GetPlayersAsync(urlQueryParameters);

            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        [HttpGet("{id:long}/detail")]
        public async Task<IActionResult> GetPlayerDetailAsync(int id)
        {
            var player = await _playerService.GetPlayerDetailAsync(id);

            if (player == null)
            {
                return NotFound($"PlayerId { id } not found.");
            }

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlayerAsync([FromBody] CreatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _playerService.CreatePlayerAsync(playerRequest);

            return Ok("Record has been added successfully.");
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> PutPlayerAsync(int id, [FromBody] UpdatePlayerRequest playerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var isUpdated = await _playerService.UpdatePlayerAsync(id, playerRequest);

            if (!isUpdated)
            {
                return NotFound($"PlayerId { id } not found.");
            }

            return Ok("Record has been updated successfully.");
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeletePlayerAsync(int id)
        {

            var isDeleted = await _playerService.DeletePlayerAsync(id);

            if (!isDeleted)
            {
                return NotFound($"PlayerId { id } not found.");
            }

            return Ok("Record has been deleted successfully.");
        }
    }
}


