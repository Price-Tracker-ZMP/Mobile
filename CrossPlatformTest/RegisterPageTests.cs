using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CrossPlatformTest
{
    [TestFixture(Platform.Android)]
    public class RegisterPageTests
    {
        IApp app;
        Platform platform;

        public RegisterPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            app.Tap(b => b.Marked("RegisterButton"));
        }

        [Test]
        public void WelcomeTextOnLoginPage()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("RegisterWelcome"));
            app.Screenshot("Register screen");

            Assert.IsTrue(results.Any());
        }

    }
}
