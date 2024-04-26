using Electron.Domain.Models;
using Electron.Logic.Forms;
using Electron.Logic.Interfaces;
using MediatR;

namespace Electron.Logic.Handlers
{
    internal class GetAncestorKidsListQueryHandler : IRequestHandler<GetAncestorsChildsRequest, List<PersonListModel>>
    {
        private readonly IPersonService _personService;
        //private readonly ILogger<GetAncestorKidsListQueryHandler> _logger; логгер для целей вывода данных в случае возникновения ошибок БЛ или исключений

        public GetAncestorKidsListQueryHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<List<PersonListModel>> Handle(GetAncestorsChildsRequest request, CancellationToken cancellationToken)
        {
            return await _personService.GetGrandGrandChildListAsync(request.Id, request.Type, request.Count, request.Offset, cancellationToken);
        }
    }
}
