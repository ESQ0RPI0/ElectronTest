﻿using Electron.Api.Forms;
using Electron.Domain.Enums;
using Electron.Domain.Models;

namespace Electron.Logic.Interfaces
{
    public interface IPersonService
    {
        Task<List<PersonListModel>> GetGrandGrandChildListAsync(long id, RelativeTypes type, int count, int offset, CancellationToken token);
        Task<List<PersonListModel>> GetListAsync(int count, int offset, CancellationToken token);
        Task<Person> GetPersonAsync(long id, RelativeTypes type, CancellationToken token);
        Task<bool> UpdatePersonAsync(UpdatePersonForm form, CancellationToken token);
    }
}