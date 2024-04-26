using Electron.Domain.Models;
using MediatR;

namespace Electron.Logic.Forms
{
    public record UpdatePersonInfoRequest(long? Id, string Name, string LastName, DateTime Birthday, long? FatherId) :
        IRequest<bool>;
}
