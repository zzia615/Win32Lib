using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace webbrowse
{
    public class Class1
    {
        [DllExport(ExportName = "NavigateToUrl",CallingConvention = CallingConvention.StdCall)]
        public static void NavigateToUrl(string title, string url, string postData)
        {
            Form1 form = new Form1(title, url, postData);
            form.ShowDialog();
        }
    }
}
