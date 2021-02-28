using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UdemyNLayerProject.Core.Models;
using UdemyNLayerProject.Core.Services;

namespace UdemyNLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IService<Person> _person;

        public PersonController(IService<Person> person)
        {
            _person = person;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ICollection<Person> persons = await _person.GetAllAsync();
            return Ok(persons);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
          Person newPerson= await  _person.AddAsync(person);
          return Ok(newPerson);
        }
    }
}