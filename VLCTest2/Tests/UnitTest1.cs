using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using VLCTest2.PageObjects;
using VLCTest2.Util;

namespace VLCTest2.Tests
{
    [TestFixture]
    public class Tests1 : BaseClass
    {
        private MainMenuPageObject mainMenuPageObject;

        [SetUp]
        public void SetUp()
        {
            mainMenuPageObject = new MainMenuPageObject(_driver);
        }

        [Test]
        public void Test()
        {
            _driver.Manage().Window.Maximize();
            mainMenuPageObject.i_Menu_View.Click();
        }



    }
}