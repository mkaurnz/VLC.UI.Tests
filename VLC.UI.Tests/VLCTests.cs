using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;

namespace VLC.UI.Tests
{
    /// <summary>
    /// UI tests for VLC media player
    /// </summary>
    public class VLCTests
    {
        private const string appiumDriverURI = "http://127.0.0.1:4723";
        private const string vlcPlayerPath = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";
        private static WindowsDriver<WindowsElement> _driver;

        [SetUp]
        public void Setup()
        {
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", vlcPlayerPath);

            _driver = new WindowsDriver<WindowsElement>(new Uri(appiumDriverURI), appiumOptions);
        }

        [TearDown]
        public void CleanUp()
        {
            if (_driver != null)
            {
                _driver.Close();
            }
        }

        [Test]
        public void PlaylistSearchTest()
        {
            // maximise VLC player
            _driver.Manage().Window.Maximize();
            
            OpenFile("c:\\temp\\test.mp4");
            OpenPlaylistSection();
            Assert.AreEqual(true, CheckItemExistsInPlaylist("test.mp4"), "item should be there before search");

            SearchPlaylistSection("abc");
            Assert.AreEqual(false, CheckItemExistsInPlaylist("test.mp4"), "item should not be there after search");

            SearchPlaylistSection("test");
            Assert.AreEqual(true, CheckItemExistsInPlaylist("test.mp4"), "item should be there after searching for the appropriate item");
        }

        private void OpenFile(string filePath)
        {
            WindowsElement mediaMenuItem = _driver.FindElement(By.Name("Media Alt+M"));
            mediaMenuItem.Click();

            // we are going to click on the Open File button by moving the mouse relative to the Media menu item
            new Actions(_driver).MoveToElement(mediaMenuItem, 20, 30).Click().Perform();

            // at this point a popup window will open so we set focus to that
            _driver.SwitchTo().Window(_driver.CurrentWindowHandle);

            // enter file name in the file name field
            _driver.FindElementByAccessibilityId("1148").SendKeys(filePath);

            // click Open button
            _driver.FindElementByAccessibilityId("1").Click();
        }

        private void OpenPlaylistSection()
        {
            var mediaElement = _driver.FindElement(By.Name("View Alt+i"));
            mediaElement.Click();

            // we are going to click on the Open File button by moving the mouse relative to the Media menu item
            new Actions(_driver).MoveToElement(mediaElement, 20, 30).Click().Perform();
        }

        private void SearchPlaylistSection(string searchText)
        {
            var searchElement = _driver.FindElementByTagName("Edit");

            // clear any text if present in the search field
            for (var i = 0; i < 10; i++)
            {
                searchElement.SendKeys(Keys.Backspace);
            }

            searchElement.SendKeys(searchText);
        }

        /// <summary>
        /// Checks if the item with the specified name is present in the Playlist
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        private bool CheckItemExistsInPlaylist(string itemName)
        {
            var items = _driver.FindElements(By.Name(itemName));
            return items.Count > 0;
        }
    }
}