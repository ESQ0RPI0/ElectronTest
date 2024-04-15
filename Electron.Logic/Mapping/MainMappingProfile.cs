using AutoMapper;
using Electron.Database.Context;
using Electron.Database.Models;
using Electron.Domain.Models;

namespace Electron.Logic.Mapping
{
    public class MainMappingProfile : Profile
    {
        public MainMappingProfile()
        {
            CreateMap<PersonDbModel, PersonListModel>();
            CreateMap<PersonDbModel, Person>();
        }
    }
}
