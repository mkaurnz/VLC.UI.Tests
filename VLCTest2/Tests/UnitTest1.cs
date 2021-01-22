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
        private MainWindowPageObject _mainWindowPageObject;

        [SetUp]
        public void SetUp()
        {
            _mainWindowPageObject = new MainWindowPageObject(_driver);
        }

        [Test]
        public void Test()
        {
            _driver.Manage().Window.Maximize();
            _mainWindowPageObject.i_Menu_View.Click();
        }



    }
}