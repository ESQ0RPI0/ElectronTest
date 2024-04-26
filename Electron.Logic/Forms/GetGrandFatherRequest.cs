using Electron.Domain.Enums;
using Electron.Domain.Models;
using MediatR;

namespace Electron.Logic.Forms
{
    public record GetGrandFatherRequest(long Id) : IRequest<Person>;
}
