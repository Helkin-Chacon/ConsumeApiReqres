using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsingApi.Controls;
using UsingApi.Droid.Renderers;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessageRenderer))]

namespace UsingApi.Droid.Renderers
{
    public class ToastMessageRenderer : IToastMessage
    {
        public void LongMessage(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortMessage(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}