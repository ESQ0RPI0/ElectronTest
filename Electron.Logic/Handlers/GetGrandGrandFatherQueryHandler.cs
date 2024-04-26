using Electron.Domain.Enums;
using Electron.Domain.Models;
using Electron.Logic.Forms;
using Electron.Logic.Interfaces;
using MediatR;

namespace Electron.Logic.Handlers
{
    internal sealed class GetGrandGrandFatherQueryHandler : IRequestHandler<GetGrandGrandFatherRequest, Person>
    {
        private readonly IPersonService _personService;

        public GetGrandGrandFatherQueryHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<Person> Handle(GetGrandGrandFatherRequest request, CancellationToken cancellationToken)
        {
            return await _personService.GetPersonAsync(request.Id, RelativeTypes.GrandGrandFather, cancellationToken);
        }
    }
}
