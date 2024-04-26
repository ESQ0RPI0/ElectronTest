using Electron.Domain.Enums;
using Electron.Domain.Models;
using MediatR;

namespace Electron.Logic.Forms
{
    public record GetListRequest(int Count, int Offset) : IRequest<IEnumerable<PersonListModel>>;
}
