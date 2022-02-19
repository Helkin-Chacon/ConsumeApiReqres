using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UsingApi.Droid.Services;
using UsingApi.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]

namespace UsingApi.Droid.Services
{
    internal class FileHelper : IFileHelper
	{
		public string GetLocalFilePath(string fileName)
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return Path.Combine(path, fileName);
		}
	}
}