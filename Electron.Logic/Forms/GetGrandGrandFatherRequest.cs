using Electron.Domain.Models;
using MediatR;

namespace Electron.Logic.Forms
{
    public record GetGrandGrandFatherRequest(long Id) : IRequest<Person>;
}
