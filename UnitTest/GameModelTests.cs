using NUnit.Framework;
using PriceTrackerMobile.Models;

namespace UnitTest
{
    [TestFixture]
    public class GameModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(300)]
        [TestCase(1567)]
        [TestCase(3450)]
        [TestCase(1000)]
        public void GameReturnProperPrice(float finalPrice)
        {
            Game game = new Game() { PriceFinal = finalPrice };

            Assert.AreEqual(finalPrice / 100, game.PriceFinal);
        }

        [TestCase(1546)]
        [TestCase(234)]
        [TestCase(10)]
        [TestCase(34534)]
        public void GameReturnProperUrlImage(int appId)
        {
            Game game = new Game() { SteamAppId = appId };

            Assert.IsTrue(game.ImageUrl.Contains("https://"));
            Assert.IsTrue(game.ImageUrl.Contains($"{appId}"));
        }
    }
}