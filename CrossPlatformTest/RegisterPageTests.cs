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

        [Test]
        public void ShowErrorToastWhenRegisterWithEmptyForm()
        {
            app.Tap(b => b.Marked("RegisterButton"));
            AppResult[] results = app.WaitForElement(t => t.Text("\"email\" must be a string"));
            app.Screenshot("Empty Form");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void ShowErrorToastWhenRegisterWithoutConfirmEmail()
        {
            app.EnterText(e => e.Marked("EmailEntry"), "admin@admin.com");
            app.PressEnter();
            app.EnterText(e => e.Marked("PasswordEntry"), "comonPassword");
            app.PressEnter();
            app.Tap(b => b.Marked("RegisterButton"));
            AppResult[] results = app.WaitForElement(t => t.Text("Passwords not equal"));
            app.Screenshot("Empty Form");

            Assert.IsTrue(results.Any());
        }
    }
}
