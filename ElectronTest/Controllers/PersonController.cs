using Electron.Api.Forms;
using Electron.Domain.Enums;
using Electron.Domain.Models;
using Electron.Logic.Forms;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ElectronTest.Controllers
{
    //кустарная валидация заменяема отдельным валидатором или FluentValidation c превалидатором от MediatR
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ISender _mediator;

        public PersonController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<PersonListModel>> GetList([FromQuery] int count, [FromQuery] int offset, CancellationToken token)
        {
            var result = await _mediator.Send(new GetListRequest(count, offset), token);

            return result;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePersonInfo([FromBody] UpdatePersonForm form, CancellationToken cancellationToken)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(form.FatherId.HasValue && form.Id.HasValue && (form.FatherId.Value == form.Id.Value))
                return BadRequest("Child cannot be father to himself");

            var result = await _mediator.Send(new UpdatePersonInfoRequest(form.Id, form.Name, form.LastName, form.Birthday, form.FatherId),
                cancellationToken);

            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGrandFatherInfo([FromQuery] long id, CancellationToken cancellationToken)
        {
            if(id < 1)
                return BadRequest("Id cannot be 0 or negative");

            var result = await _mediator.Send(new GetGrandFatherRequest(id), cancellationToken);

            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGrandGrandFatherInfo([FromQuery] long id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Id cannot be 0 or negative");

            var result = await _mediator.Send(new GetGrandGrandFatherRequest(id), cancellationToken);

            return Ok(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetGrandGrandFatherKidsList([FromQuery] long id, [FromQuery] int offset, [FromQuery] int count, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Id cannot be 0 or negative");

            if(count < 1)
                return BadRequest("Count cannot be 0 or negative");

            var result = await _mediator.Send(new GetAncestorsChildsRequest(id, RelativeTypes.GrandGrandFather, count, offset), cancellationToken);

            return Ok(result);
        }
    }
}
