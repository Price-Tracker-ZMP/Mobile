using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CrossPlatformTest
{
    [TestFixture(Platform.Android)]
    public class LoginPageTests
    {
        IApp app;
        Platform platform;

        public LoginPageTests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextOnLoginPage()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("LoginWelcome"));
            app.Screenshot("Login screen");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void ShowErrorToastWhenLoginWithWrongEmailFormat()
        {
            app.EnterText(e => e.Marked("EmailEntry"), "wrongemail.com");
            app.Tap(b => b.Marked("LoginButton"));
            AppResult[] results = app.WaitForElement(t => t.Text("\"email\" must be a valid email"));
            app.Screenshot("Wrong email");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void ShowErrorToastWhenLoginWithEmptyPassword()
        {
            app.EnterText(e => e.Marked("EmailEntry"), "wronge@mail.com");
            app.Tap(b => b.Marked("LoginButton"));
            AppResult[] results = app.WaitForElement(t => t.Text("\"password\" is not allowed to be empty"));
            app.Screenshot("Empty passowrd");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void ShowErrorToastWhenLoginWithWrongPassword()
        {
            app.EnterText(e => e.Marked("EmailEntry"), "admin@admin.com");
            app.EnterText(e => e.Marked("PasswordEntry"), "sdgdfghrtru");
            app.Tap(b => b.Marked("LoginButton"));
            AppResult[] results = app.WaitForElement(t => t.Text("Wrong Password"));
            app.Screenshot("Wrong Password");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void ShowSuccessToastWhenLogin()
        {
            app.EnterText(e => e.Marked("EmailEntry"), "admin@admin.com");
            app.EnterText(e => e.Marked("PasswordEntry"), "admin");
            app.Tap(b => b.Marked("LoginButton"));
            AppResult[] results = app.WaitForElement(t => t.Text("Login"));
            app.Screenshot("Successfull login");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void NavigateToRegisterPage()
        {
            app.Tap(b => b.Marked("RegisterButton"));
            AppResult[] results = app.WaitForElement(t => t.Text("Welcome to register page!"));
            app.Screenshot("Navigation to register page");

            Assert.IsTrue(results.Any());
        }
    }
}
