using Electron.Api.Forms;
using Electron.Domain.Enums;
using Electron.Domain.Models;
using Electron.Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ElectronTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<PersonListModel>> GetList([FromQuery] int count, [FromQuery] int offset, CancellationToken token)
        {
            var result = await _personService.GetListAsync(count, offset, token);

            return result;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<bool> UpdatePersonInfo([FromBody]UpdatePersonForm form, CancellationToken cancellationToken)
        {
            return await _personService.UpdatePersonAsync(form, cancellationToken);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<Person> GetGrandFatherInfo([FromQuery]long id, CancellationToken cancellationToken)
        {
            return await _personService.GetPersonAsync(id, RelativeTypes.GrandFather, cancellationToken);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<Person> GetGrandGrandFatherInfo([FromQuery] long id, CancellationToken cancellationToken)
        {
            return await _personService.GetPersonAsync(id, RelativeTypes.GrandGrandFather, cancellationToken);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<List<PersonListModel>> GetGrandGrandFatherKidsList([FromQuery] long id, [FromQuery] int offset, [FromQuery] int count, CancellationToken cancellationToken)
        {
            return await _personService.GetGrandGrandChildListAsync(id, RelativeTypes.GrandGrandFather, count, offset, cancellationToken);
        }
    }
}
