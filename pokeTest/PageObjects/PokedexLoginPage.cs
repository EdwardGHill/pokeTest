using System;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CalculatorSelenium.Specs.PageObjects
{
    /// <summary>
    /// Pokedex Page Object
    /// </summary>
    public class PokedexPageObject
    {
        //The URL of the calculator to be opened in the browser
        private const string pokedexUrl = "https://pokedex-d0ok.onrender.com";

        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public PokedexPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        //Finding elements by XPATH (not the best option
        private IWebElement PokeDexImage => _webDriver.FindElement(By.XPath("/html/body/div/div/div/img"));
        private IWebElement UsernameInputBox => _webDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]/form/label[1]/input"));
        private IWebElement PasswordInputBox => _webDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]/form/label[2]/input"));
        private IWebElement LoginButton => _webDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[1]/form/button"));
      //  private IWebElement LoginErrorText => _webDriver.FindElement(By.XPath("/html/body/div/div/div/div/div[2]/div/p"));

        public void EnterUsername(string username)
        {
            //Clear text box
            UsernameInputBox.Clear();
            //Enter text
            UsernameInputBox.SendKeys(username);
        }

        public void EnterPsssword(string password)
        {
            //Clear text box
            PasswordInputBox.Clear();
            //Enter text
            PasswordInputBox.SendKeys(password);
        }

        public void ClickLogin()
        {
            //Click the add button
            LoginButton.Click();
        }

        public bool IsOpen()
        {
            if (PokeDexImage.GetAttribute("alt") == "Pokedex Logo");
            {
                return true;
            } 
        }

        public void EnsurePokedexIsOpenAndReset()
        {
            //Open the calculator page in the browser if not opened yet
            if (_webDriver.Url != pokedexUrl)
            {
                _webDriver.Url = pokedexUrl;
            }
            //Otherwise reset the calculator by clicking the reset button
            else
            {
                throw new InvalidOperationException();
            }
        }



        public string ErrorMessageTextDisplayed()
        {

            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            return _webDriver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div/div/div[2]/div/p")).Text;
            
           
        }


      
    }
    }

