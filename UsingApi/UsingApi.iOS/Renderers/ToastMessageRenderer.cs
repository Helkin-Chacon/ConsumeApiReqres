using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using UsingApi.Controls;
using UsingApi.iOS.Renderers;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessageRenderer))]

namespace UsingApi.iOS.Renderers
{
    public class ToastMessageRenderer : IToastMessage
    {
        const double longDelay = 5;
        const double shortDelay = 3;

        NSTimer alertDelay;
        UIAlertController alert;

        public void LongMessage(string message)
        {
            ShowAlert(message, longDelay);
        }

        public void ShortMessage(string message)
        {
            ShowAlert(message, shortDelay);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dismissMessage();
            });
            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dismissMessage()
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }
            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}