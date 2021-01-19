using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;

namespace VLC.UI.Tests
{
    public class VLCTests
    {
        private const string appiumDriverURI = "http://127.0.0.1:4723";
        private static WindowsDriver<WindowsElement> _driver;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void PlaylistSearchTest()
        {

            if (_driver == null)
            {
                AppiumOptions appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");

                _driver = new WindowsDriver<WindowsElement>(new Uri(appiumDriverURI), appiumOptions);
                _driver.Manage().Window.Maximize();

                OpenFile("c:\\temp\\test.mp4");
                OpenPlaylist();
                Assert.AreEqual(true, CheckItemExistsInPlaylist("test.mp4"), "item should be there before search");

                SearchPlaylist("abc");
                Assert.AreEqual(false, CheckItemExistsInPlaylist("test.mp4"), "item should not be there after search");

                SearchPlaylist("test");
                Assert.AreEqual(true, CheckItemExistsInPlaylist("test.mp4"));

               
            }
        }

        private void OpenFile(string filePath)
        {
            var mediaElement = _driver.FindElement(By.Name("Media Alt+M"));
            mediaElement.Click();
            new Actions(_driver).MoveToElement(mediaElement, 20, 30).Click().Perform();
            //_driver.Keyboard.SendKeys("x");
            _driver.SwitchTo().Window(_driver.CurrentWindowHandle);
            _driver.FindElementByAccessibilityId("1148").SendKeys(filePath);
            _driver.FindElementByAccessibilityId("1").Click();
        }

        private void OpenPlaylist()
        {
            var mediaElement = _driver.FindElement(By.Name("View Alt+i"));
            mediaElement.Click();
            new Actions(_driver).MoveToElement(mediaElement, 20, 30).Click().Perform();
        }

        private void SearchPlaylist(string searchText)
        {
            var editElement = _driver.FindElementByTagName("Edit");
            editElement.SendKeys(Keys.Backspace);
            editElement.SendKeys(Keys.Backspace);
            editElement.SendKeys(Keys.Backspace);
            editElement.SendKeys(Keys.Backspace);
            editElement.SendKeys(searchText);
        }


        private bool CheckItemExistsInPlaylist(string itemName)
        {
            var items = _driver.FindElements(By.Name(itemName));
            return items.Count > 0;
        }
    }
}