using Electron.Api.Forms;
using Electron.Domain.Enums;
using Electron.Domain.Models;
using Electron.Logic.Forms;

namespace Electron.Logic.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonListModel>> GetGrandGrandChildListAsync(long id, RelativeTypes type, int count, int offset, CancellationToken token);
        Task<IEnumerable<PersonListModel>> GetListAsync(int count, int offset, CancellationToken token);
        Task<Person> GetPersonAsync(long id, RelativeTypes type, CancellationToken token);
        Task<bool> UpdatePersonAsync(UpdatePersonInfoRequest form, CancellationToken token);
    }
}
