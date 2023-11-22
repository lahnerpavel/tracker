using Microsoft.AspNetCore.Mvc;
using Tracker.Api.Interfaces;
using Tracker.Api.Models;
using Tracker.Data.Models;

namespace Tracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonManager personManager;


        public PeopleController(IPersonManager personManager)
        {
            this.personManager = personManager;
        }


        [HttpGet]
        public IEnumerable<PersonDto> GetPeople()
        {
            return personManager.GetAllPeople();
        }

        [HttpGet("{personId}")]
        public IActionResult GetPerson(uint personId)
        {
            PersonDto? person = personManager.GetPerson(personId);

            if (person is null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult AddPerson([FromBody] PersonDto person)
        {
            PersonDto? createdPerson = personManager.AddPerson(person);
            return CreatedAtAction(nameof(GetPerson), new { personId = createdPerson.PersonId }, createdPerson);
        }

        [HttpPut("{personId}")]
        public IActionResult EditPerson(uint personId, [FromBody] PersonDto person)
        {
            PersonDto? updatedPerson = personManager.UpdatePerson(personId, person);

            if (updatedPerson is null)
                return NotFound();

            return Ok(updatedPerson);
        }

        [HttpDelete("{personId}")]
        public IActionResult DeletePerson(uint personId)
        {
            PersonDto? deletedPerson = personManager.DeletePerson(personId);

            if (deletedPerson is null)
                return NotFound();

            return Ok(deletedPerson);
        }

        [HttpGet("actors")]
        public IEnumerable<PersonDto> GetActors(int limit = int.MaxValue)
        {
            return personManager.GetAllPeople(PersonRole.Actor, 0, limit);
        }

        [HttpGet("directors")]
        public IEnumerable<PersonDto> GetDirectors(int limit = int.MaxValue)
        {
            return personManager.GetAllPeople(PersonRole.Director, 0, limit);
        }
    }
}