using Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using UsingApi.iOS.Services;
using UsingApi.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]

namespace UsingApi.iOS.Services
{
    public class FileHelper : IFileHelper
    {
      
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libfolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libfolder))
            {
                Directory.CreateDirectory(libfolder);
            }
            return Path.Combine(libfolder, fileName);
        }
    }
}