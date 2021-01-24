using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Appium.Windows;

namespace VLCTest2.PageObjects
{
    class FileDialogPageObject
    {
        WindowsDriver<WindowsElement> _driver;

        public FileDialogPageObject(WindowsDriver<WindowsElement> driver)
        {
           this._driver = driver;
        }

        public WindowsElement i_File_Name => _driver.FindElementByAccessibilityId("1148");
        public WindowsElement i_Open_Button => _driver.FindElementByAccessibilityId("1");
    }
}
