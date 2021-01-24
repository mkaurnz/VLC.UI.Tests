using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace VLCTest2.Util
{
    public class UtilClass: Constants
    {
        public void SwitchToCurrentWindow()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            var allWindowHandles2 = _driver.WindowHandles;
            _driver.SwitchTo().Window(allWindowHandles2[0]);
        }

        public void SwitchToPreviousWindow()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            var allWindowHandles2 = _driver.WindowHandles;
            _driver.SwitchTo().Window(allWindowHandles2[1]);
        }
    }
}
