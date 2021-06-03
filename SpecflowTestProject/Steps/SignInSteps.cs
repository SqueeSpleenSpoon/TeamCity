﻿using System.Linq;
using System.Threading;
using NewBookModelsApiTests.Models.Auth;
using OpenQA.Selenium;
using SeleniumTests.POM;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowTestProject.Steps.UI
{
    [Binding]
    public class SignInSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly SingInPage _singInPage;

        public SignInSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var webDriver = _scenarioContext.Get<IWebDriver>(Context.WebDriver);
            _singInPage = new SingInPage(webDriver);
        }

        [Given(@"Sign in page is opened")]
        public void GivenSignInPageIsOpened()
        {
            _singInPage.OpenPage();
        }

        [When(@"I input email of created client in email field")]
        public void WhenIInputEmailOfCreatedClientInEmailField()
        {
            var user = _scenarioContext.Get<ClientAuthModel>(Context.User);
            _singInPage.SetEmail(user.User.Email);
        }

        [When(@"I enter (.*|^NULL$) in LogIn field")]
        public void WhenIEnterLoginInLogInField(string login)
        {
            _singInPage.SetEmail(login);
        }


        [When(@"I click on another area")]
        public void WhenIClickOnAnotherArea()
        {
            _singInPage.SetPassword("123");
        }

        [When(@"I input password of created client in password field")]
        public void WhenIInputPasswordOfCreatedClientInEmailField()
        {
            _singInPage.SetPassword(Constants.Password);
        }

        [When(@"I click Log in button")]
        public void WhenIClickLogInButton()
        {
            _singInPage.ClickLoginButton();
        }

        [When(@"I login with data")]
        public void ILoginWithData(Table table)
        {
            var loginModels = table.CreateSet<LoginModel>().ToList();

            _singInPage.SetEmail(loginModels[0].Email);
            _singInPage.SetPassword(loginModels[0].Password);
            _singInPage.ClickLoginButton();
        }


        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }


    }
}