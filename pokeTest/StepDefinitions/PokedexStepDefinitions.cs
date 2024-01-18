using CalculatorSelenium.Specs.Drivers;
using CalculatorSelenium.Specs.PageObjects;
using OpenQA.Selenium.DevTools.V118.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using OpenQA.Selenium;



namespace pokeTest.StepDefinitions
{
    [Binding]



    internal class PokedexStepDefinitions
    {

        private string? _username;
        private string? _password;
        private readonly PokedexPageObject _pokeDexPageObject;

        public PokedexStepDefinitions(BrowserDriver browserDriver)
        {
            _pokeDexPageObject = new PokedexPageObject(browserDriver.Current);
        }


        [Given(@"I open the Pokedex app")]
        public void GivenIOpenThePokedexApp()
        {
            _pokeDexPageObject.EnsurePokedexIsOpenAndReset();
        }




        [Given(@"I enter a valid username")]
        public void GivenIEnterAValidUsername()
        {
            _username = "adamx123654";
            _pokeDexPageObject.EnterUsername(_username);
        }

        [Given(@"I enter a valid password")]
        public void GivenIEnterAValidPassword()
        {
            _password = "Qwertyuiop1!";
            _pokeDexPageObject.EnterPsssword(_password);
        }

        // with this one, i can actually start to combine existing methods to speed things up
        // from a specflow step perspective. Rather than puttting Given.. And.. And.. And.. 
        // you can rationalise is you want
        [Given(@"I am using a valid username and password")]
        public void GivenIAmUsingAValidUsernameAndPassword()
        {
            GivenIEnterAValidUsername();
            GivenIEnterAValidPassword();

        }

        [When(@"I click the Login button")]
        public void WhenIClickTheLoginButton()
        {

            _pokeDexPageObject.ClickLogin();
                
        }


        [Then(@"I am successfully logged in")]
        public void ThenIAmSuccessfullyLoggedIn()
        {
            throw new PendingStepException();
        }

        [Given(@"I enter '([^']*)' as my username")]
        public void GivenIEnterAsMyUsername(string username)
        {
            _pokeDexPageObject.EnterUsername(username);
        }

        [Given(@"I enter '([^']*)' as my password")]
        public void GivenIEnterAsMyPassword(string password)
        {
            _pokeDexPageObject.EnterPsssword(password);
        }
       
        [Then(@"A login error message is displayed")]
        public void ThenALoginErrorMessageIsDisplayed()
        {

            _pokeDexPageObject.ErrorMessageTextDisplayed().Should().Be("Login details not recognised.");



        }


    }
}
