using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Text;

namespace VLCTest2.PageObjects
{
    class MainWindowPageObject
    {
        WindowsDriver<WindowsElement> _driver;

        public MainWindowPageObject(WindowsDriver<WindowsElement> driver)
        {
            _driver = driver;
        }

        public WindowsElement i_Menu_Media => _driver.FindElementByName("Media Alt+M");

        public WindowsElement i_Menu_View => _driver.FindElementByName("View Alt+i");

        public WindowsElement i_Menu_Audio => _driver.FindElementByName("Audio Alt+A");

        public WindowsElement i_Search_Bar => _driver.FindElementByTagName("Edit");
    }
}




















