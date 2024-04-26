using Electron.Domain.Enums;
using Electron.Domain.Models;
using Electron.Logic.Forms;
using Electron.Logic.Interfaces;
using MediatR;

namespace Electron.Logic.Handlers
{
    internal class GetGrandFatherQueryHandler : IRequestHandler<GetGrandFatherRequest, Person>
    {
        private readonly IPersonService _personService;

        public GetGrandFatherQueryHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<Person> Handle(GetGrandFatherRequest request, CancellationToken cancellationToken)
        {
            return await _personService.GetPersonAsync(request.Id, RelativeTypes.GrandFather, cancellationToken);
        }
    }
}
