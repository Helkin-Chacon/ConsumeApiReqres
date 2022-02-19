using System;
using System.Collections.Generic;
using System.Text;

namespace UsingApi.Services
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string fileName);
    }
}
