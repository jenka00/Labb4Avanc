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
    public class InterestsController : ControllerBase
    {
        private ILabb4Avanc<Interest> _labb4Avanc;

        public InterestsController(ILabb4Avanc<Interest> labb4Avanc)
        {
            _labb4Avanc = labb4Avanc;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            return Ok(await _labb4Avanc.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Interest>> GetInterest(int id)
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
                    "Error to retrive single interest from database....");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Interest>> CreateNewProduct(Interest newInterest)
        {
            try
            {
                if (newInterest == null)
                {
                    return BadRequest();
                }
                var createdInterest = await _labb4Avanc.Add(newInterest);

                return CreatedAtAction(nameof(GetInterest), new { id = createdInterest.InterestId }, createdInterest);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive single interest from database....");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Interest>> DeleteInterest(int id)
        {
            try
            {
                var interestToDelete = await _labb4Avanc.GetSingle(id);
                if (interestToDelete == null)
                {
                    return NotFound($"Interest with ID: {id} not found......");
                }
                return await _labb4Avanc.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete single interest from database....");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Interest>> UpdateInterest(int id, Interest pro)
        {
            try
            {
                if (id != pro.InterestId)
                {
                    return BadRequest($"Interest ID {id} doesn't match.....");
                }
                var interestToUpdate = await _labb4Avanc.GetSingle(id);
                if (interestToUpdate == null)
                {
                    return NotFound($"Interest with ID {id} not found....");
                }
                return await _labb4Avanc.Update(pro);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to find single interest from database....");
            }
        }
    }
}
