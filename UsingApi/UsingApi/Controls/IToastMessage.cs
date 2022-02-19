using System;
using System.Collections.Generic;
using System.Text;

namespace UsingApi.Controls
{
    public interface IToastMessage
    {
        void LongMessage(string message);
        void ShortMessage(string message);
    }
}
