using System;
using System.Collections.Generic;
using System.Text;

namespace base64net
{
    public static class Class1
    {
        [DllExport(ExportName = "Base64Encode", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static string Base64Encode(string encode, string data)
        {
            try
            {
                var bytes = Encoding.GetEncoding(encode).GetBytes(data);
                string temp = Convert.ToBase64String(bytes);
                // 在此处放置代码
                return temp;
            }
            catch
            {
                return data;
            }
        }
        [DllExport(ExportName = "Base64Decode", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static string Base64Decode(string encode, string data)
        {
            try
            {
                var bytes = Convert.FromBase64String(data);
                var temp = Encoding.GetEncoding(encode).GetString(bytes);
                // 在此处放置代码
                return  temp;
            }
            catch
            {
                return  data;
            }
        }
    }
}
