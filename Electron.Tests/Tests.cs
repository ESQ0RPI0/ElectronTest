using AutoMapper;
using Electron.Database.Context;
using Electron.Database.Models;
using Electron.Logic;
using Electron.Logic.Interfaces;
using Electron.Logic.Mapping;
using ElectronTest.Controllers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using NUnit.Framework;
namespace Electron.Tests
{
    [TestFixture]
    public class Tests
    {
        private ISender _sender;
        private PersonController personController;
        private IPersonService personService;
        private IMapper _mapper;

        private DbContextOptions<PersonDbContext> _dbContextOptions;
        private PersonDbContext _personDbContext;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<PersonDbContext>()
            .UseInMemoryDatabase("PersonControllerTest")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            var myProfile = new MainMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);

            //инициализация базовых сущностей для списка
        }

        //инициализация контекста для целей проверки записи сервиса
        //т.к. валидация отдельным сервисом не реализованна - тест требует мока всей цепочки зависимостей
        [SetUp]
        public async Task Setup()
        {
            _personDbContext = new PersonDbContext(_dbContextOptions);

            _personDbContext.Database.EnsureDeleted();
            _personDbContext.Database.EnsureCreated();
        }

        [TearDown]
        public async Task TearDown()
        {
            await _personDbContext.DisposeAsync();
        }

        [Test]
        public async Task GetList_DefaultParams_Success()
        {
            var mockList = new List<PersonDbModel> { new PersonDbModel { Id = 1, Name = "a", LastName = "a" },
            new PersonDbModel { Id = 2, Name = "b", LastName = "b" },
            new PersonDbModel { Id = 3, Name = "c", LastName = "c" }};

            var mockSet = new Mock<DbSet<PersonDbModel>>();
            mockSet.As<IQueryable<PersonDbModel>>().Setup(u => u.GetEnumerator()).Returns(() => mockList.GetEnumerator());

            var mockContext = new Mock<PersonDbContext>();
            mockContext.Setup(m => m.Persons).Returns(mockSet.Object);
            //инициализация контроллера и сендера, их функционал уникальный для каждого теста т.е. мока надо разные метода, в зависимости от теста

            var ps = new PersonService(mockContext.Object, _mapper);

            var result = await ps.GetListAsync(1, 0, CancellationToken.None);

            Assert.That(result.Any());
        }
    }
}
