using Electron.Domain.Enums;
using Electron.Domain.Models;
using MediatR;

namespace Electron.Logic.Forms
{
    public record GetAncestorsChildsRequest(long Id, RelativeTypes Type, int Offset, int Count) : IRequest<List<PersonListModel>>;
}
