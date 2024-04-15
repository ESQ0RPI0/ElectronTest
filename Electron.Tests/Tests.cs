using AutoMapper;
using Electron.Database.Context;
using Electron.Logic.Interfaces;
using Moq;
using NUnit.Framework;

namespace Electron.Tests
{
    public class Tests
    {
        private IPersonService personService;

        [OneTimeSetUp]
        public void Init()
        {
            personService = Mock.Get<IPersonService>();
        }

        [Test]
        public async Task CreateUser_Add_Success()
        {

        }
        [Test]
        public async Task CreateUser_UpdateName_Success()
        {

        }
        [Test]
        public async Task CreateUser_GetList_Success()
        {

        }
        [Test]
        public async Task CreateUsers_GetGrandFather_Success()
        {

        }
        [Test]
        public async Task CreateUsers_GetGrandGrandFather_Success()
        {

        }
    }
}
