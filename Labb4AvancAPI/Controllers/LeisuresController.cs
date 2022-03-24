using Labb4Avanc.Models;
using Labb4AvancAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvancAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeisuresController : ControllerBase
    {
        private ILabb4Avanc<Leisure> _labb4Avanc;

        public LeisuresController(ILabb4Avanc<Leisure> labb4Avanc)
        {
            _labb4Avanc = labb4Avanc;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLeisures()
        {
            return Ok(await _labb4Avanc.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Leisure>> GetLeisure(int id)
        {
            try
            {
                var result = await _labb4Avanc.GetSingle(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive single leisure from database....");
            }
        }      

        [HttpPost]
        public async Task<ActionResult<Leisure>> CreateNewLeisure(Leisure newLeisure)
        {
            try
            {
                if (newLeisure == null)
                {
                    return BadRequest();
                }
                var createdLeisure = await _labb4Avanc.Add(newLeisure);

                return CreatedAtAction(nameof(GetLeisure), new { id = createdLeisure.LeisureId }, createdLeisure);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive single leisure from database....");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Leisure>> DeleteLeisure(int id)
        {
            try
            {
                var leisureToDelete = await _labb4Avanc.GetSingle(id);
                if (leisureToDelete == null)
                {
                    return NotFound($"Leisure with ID: {id} not found......");
                }
                return await _labb4Avanc.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete single leisure from database....");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Leisure>> UpdateLeisure(int id, Leisure leisure)
        {
            try
            {
                if (id != leisure.LeisureId)
                {
                    return BadRequest($"Leisure ID {id} doesn't match.....");
                }
                var leisureToUpdate = await _labb4Avanc.GetSingle(id);
                if (leisureToUpdate == null)
                {
                    return NotFound($"Leisure with ID {id} not found....");
                }
                return await _labb4Avanc.Update(leisure);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to find single leisure from database....");
            }
        }
    }
}
