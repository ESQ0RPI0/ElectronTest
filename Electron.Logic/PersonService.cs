using AutoMapper;
using Electron.Api.Forms;
using Electron.Database.Context;
using Electron.Database.Models;
using Electron.Domain.Enums;
using Electron.Domain.Models;
using Electron.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Electron.Logic
{
    public sealed class PersonService : IPersonService
    {
        private readonly PersonDbContext _dc;
        private readonly IMapper _mapper;

        public PersonService(PersonDbContext dc, IMapper mapper)
        {
            _dc = dc;
            _mapper = mapper;
        }

        public async Task<List<PersonListModel>> GetListAsync(int count, int offset, CancellationToken token)
        {
            var list = await _dc.Persons
                .AsNoTracking()
                .Skip(offset)
                .Take(count)
                .ToListAsync(token);

            return _mapper.Map<List<PersonListModel>>(list);
        }
        public async Task<Person> GetPersonAsync(long id, RelativeTypes type, CancellationToken token)
        {
            return type switch
            {
                RelativeTypes.GrandFather => await GetGrandFatherAsync(id, token),
                RelativeTypes.GrandGrandFather => await GetGrandGrandFatherAsync(id, token),
                _ => throw new NotImplementedException()
            };
        }
        public async Task<List<PersonListModel>> GetGrandGrandChildListAsync(long id, RelativeTypes type, int count, int offset, CancellationToken token)
        {
            var people = await _dc.Persons
                .AsNoTracking()
                .Include(u => u.Kids)
                .Where(u => u.GrandFatherId.HasValue && u.GrandFather.FatherId == id)
                .ToListAsync(token);

            return _mapper.Map<List<PersonListModel>>(people);
        }

        public async Task<bool> UpdatePersonAsync(UpdatePersonForm form, CancellationToken token)
        {
            var father = await GetFatherAsync(form, token);

            if (father is null && form.FatherId.HasValue)
                return false;

            PersonDbModel? entity = default;

            if (form.Id.HasValue)
                entity = await _dc.Persons.FirstOrDefaultAsync(u => u.Id == form.Id.Value, token);            

            if (entity is null)
                entity = new PersonDbModel();

            entity.Birthday = form.Birthday;
            entity.Name = form.Name;
            entity.LastName = form.LastName;
            entity.GrandFatherId = father.FatherId;
            entity.FatherId = form.FatherId;

            _dc.Persons.Add(entity);

            await _dc.SaveChangesAsync(token);

            return true;
        }

        private async Task<PersonDbModel?> GetFatherAsync(UpdatePersonForm form, CancellationToken token)
        {
            if (!form.FatherId.HasValue)
                return null;

            return await _dc.Persons
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == form.FatherId.Value, token);
        }

        private async Task<Person> GetGrandGrandFatherAsync(long personId, CancellationToken token)
        {
            var person = await _dc.Persons
                .Include(u => u.GrandFather)
                .ThenInclude(u => u.Father)
                .Where(u => u.Id == personId)
                .Select(u => u.GrandFather.Father)
                .FirstOrDefaultAsync(token);

            return _mapper.Map<Person>(person);
        }

        private async Task<Person> GetGrandFatherAsync(long personId, CancellationToken token)
        {
            var person = await _dc.Persons
                .Include(u => u.GrandFather)
                .ThenInclude(u => u.Father)
                .Include(u => u.GrandFather)
                .ThenInclude(u => u.GrandFather)
                .Where(u => u.Id == personId)
                .Select(u => u.GrandFather)
                .FirstOrDefaultAsync(token);

            var mapped = _mapper.Map<Person>(person);

            return mapped;
        }


    }
}
