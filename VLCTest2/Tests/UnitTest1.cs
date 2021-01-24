using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Security.Cryptography.X509Certificates;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using VLCTest2.PageObjects;
using VLCTest2.Util;

namespace VLCTest2.Tests
{
    [TestFixture]
    public class Tests1 : BaseClass
    {
        private MainWindowPageObject _mainWindowPageObject;
        private FileDialogPageObject _fileDialogPageObject;
        private UtilClass _util = new UtilClass();

        [SetUp]
        public void SetUp()
        {
            _mainWindowPageObject = new MainWindowPageObject(_driver);
            _fileDialogPageObject = new FileDialogPageObject(_driver);
        }

        [TearDown]
        public void TearDown()
        { 
            _driver.Close();
        }

        [Test]

        public void Test()
        {
            _driver.Manage().Window.Maximize();
            _mainWindowPageObject.i_Menu_Media.Click();

            new Actions(_driver).MoveToElement(_mainWindowPageObject.i_Menu_Media, 0, 0).MoveByOffset(30, 30).Click().Perform();

            _util.SwitchToCurrentWindow();
            _fileDialogPageObject.i_File_Name.SendKeys("c:\\temp\\test.mp4");
            _fileDialogPageObject.i_Open_Button.Click();
            _mainWindowPageObject.i_Menu_View.Click();

            new Actions(_driver).MoveToElement(_mainWindowPageObject.i_Menu_View, 0, 0).MoveByOffset(30, 30).Click().Perform();

            _mainWindowPageObject.i_Search_Bar.SendKeys("abc");
            Assert.IsFalse(PresentInPlaylist(), "test.mp4 should not be present in the playlist");

            _mainWindowPageObject.i_Search_Bar.SendKeys(Keys.Backspace + Keys.Backspace + Keys.Backspace + "test.mp4");
            Assert.IsTrue(PresentInPlaylist());
        }

        private bool PresentInPlaylist()
        {
            var items = _driver.FindElementsByName("test.mp4");
            return items.Count > 0;
        }
    }
}