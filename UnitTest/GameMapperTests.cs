using NUnit.Framework;
using PriceTrackerMobile.Mapper;
using PriceTrackerMobile.Models;
using System;
using System.Linq;

namespace UnitTest
{
    [TestFixture]
    public class GameMapperTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(334, "Test1")]
        [TestCase(35634, "Test2")]
        [TestCase(3764, "Test3")]
        [TestCase(1614, "Test4")]
        public void GameMapperChangeFetchedGameToGame(int appId, string name)
        {
            FetchedGame fetchedgame = new FetchedGame() { Appid = appId, Name = name };
            Game game = GameMapper.ConvertFetchedGame(fetchedgame);

            Assert.IsTrue(fetchedgame.Name == game.Name);
            Assert.IsTrue(fetchedgame.Appid == game.SteamAppId);
        }
    }
}
