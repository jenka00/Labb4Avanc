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
    public class PersonsController : ControllerBase
    {
        private ILabb4Avanc<Person> _labb4Avanc;

        public PersonsController(ILabb4Avanc<Person> labb4Avanc)
        {
            _labb4Avanc = labb4Avanc;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {            
            return Ok(await _labb4Avanc.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
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
                    "Error to retrive single person from database....");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Person>> CreateNewProduct(Person newPerson)
        {
            try
            {
                if (newPerson == null)
                {
                    return BadRequest();
                }
                var createdPerson = await _labb4Avanc.Add(newPerson);

                return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.PersonId }, createdPerson);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrive single person from database....");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            try
            {
                var personToDelete = await _labb4Avanc.GetSingle(id);
                if (personToDelete == null)
                {
                    return NotFound($"Person with ID: {id} not found......");
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
        public async Task<ActionResult<Person>> UpdateInterest(int id, Person person)
        {
            try
            {
                if (id != person.PersonId)
                {
                    return BadRequest($"Person ID {id} doesn't match.....");
                }
                var personToUpdate = await _labb4Avanc.GetSingle(id);
                if (personToUpdate == null)
                {
                    return NotFound($"Person with ID {id} not found....");
                }
                return await _labb4Avanc.Update(person);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to find single person from database....");
            }
        }
    }
}
