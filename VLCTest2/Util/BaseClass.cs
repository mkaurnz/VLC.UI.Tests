using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace VLCTest2.Util
{
    public class BaseClass: Constants
    {
        /**
         *  Common SetUp Methods
         */
        [OneTimeSetUp]
        public void Setup()
        {
            AppiumOptions appOptions = new AppiumOptions();

            appOptions.AddAdditionalCapability("app", "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe");
            appOptions.AddAdditionalCapability("deviceName", "WindowsPC");

            _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appOptions);
        }
    }
}
