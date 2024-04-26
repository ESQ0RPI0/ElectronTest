using Electron.Domain.Models;
using Electron.Logic.Forms;
using Electron.Logic.Interfaces;
using MediatR;

namespace Electron.Logic.Handlers
{
    internal sealed class GetListQueryHandler : IRequestHandler<GetListRequest, IEnumerable<PersonListModel>>
    {
        private readonly IPersonService _personService;

        public GetListQueryHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<IEnumerable<PersonListModel>> Handle(GetListRequest request, CancellationToken cancellationToken)
        {
            return await _personService.GetListAsync(request.Count, request.Offset, cancellationToken);
        }
    }
}
