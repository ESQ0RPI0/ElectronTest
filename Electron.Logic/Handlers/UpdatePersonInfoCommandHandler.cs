using Electron.Logic.Forms;
using Electron.Logic.Interfaces;
using MediatR;

namespace Electron.Logic.Handlers
{
    internal sealed class UpdatePersonInfoCommandHandler : IRequestHandler<UpdatePersonInfoRequest, bool>
    {
        private readonly IPersonService _personService;

        public UpdatePersonInfoCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }

        public async Task<bool> Handle(UpdatePersonInfoRequest request, CancellationToken cancellationToken)
        {
            return await _personService.UpdatePersonAsync(request, cancellationToken);
        }
    }
}
