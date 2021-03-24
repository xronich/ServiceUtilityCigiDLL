using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ServiceUtilityCigiDLL
{
    public static class Parse
    {
        public static bool ToBool(this string result)
        {
            return (result == "1");
        }

        public static int ToInt32(this string result)
        {
            return Int32.Parse(result);
        }

        public static Dictionary<string, string> ToStringString(this IntPtr result)
        {
            string str = Marshal.PtrToStringAnsi(result);

            string[] splitStr = str.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> dictinary =
                      splitStr.ToDictionary(s => s.Split('=')[0], s => (s.Split('=')[1]));

            return dictinary;
        }

        public static Dictionary<string, float> ToStringFloat(this IntPtr result)
        {
            string str = Marshal.PtrToStringAnsi(result);

            string[] splitStr = str.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, float> dictionary =
                      splitStr.ToDictionary(s => s.Split('=')[0], s => float.Parse(s.Split('=')[1].Replace('.', ',')));

            return dictionary;
        }

        public static Dictionary<string, int> ToStringInt(this IntPtr result)
        {
            string str = Marshal.PtrToStringAnsi(result);

            string[] splitStr = str.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dictionary =
                      splitStr.ToDictionary(s => s.Split('=')[0], s => Int32.Parse(s.Split('=')[1]));

            return dictionary;
        }
        public static Dictionary<string, string> ToStringString(this string result)
        {
            string[] splitStr = result.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, string> dictionary =
                      splitStr.ToDictionary(s => s.Split('-')[0], s => s.Split('-')[1]);

            return dictionary;
        }

        public static Dictionary<string, float> ToStringFloat(this string result)
        {
            string[] splitStr = result.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, float> dictionary =
                splitStr.ToDictionary(s => s.Split('-')[0], s => float.Parse(s.Split('-')[1].Replace('.', ',')));

            return dictionary;
        }

        public static Dictionary<int, string> ToIntString(this string result)
        {
            string[] splitStr = result.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, string> dictionary =
                      splitStr.ToDictionary(s => Int32.Parse(s.Split('-')[0]), s => s.Split('-')[1]);

            return dictionary;
        }

        public static Dictionary<int, int> ToIntInt(this string result)
        {
            string[] splitStr = result.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, int> dictionary =
                      splitStr.ToDictionary(s => Int32.Parse(s.Split('-')[0]), s => Int32.Parse(s.Split('-')[1]));

            return dictionary;
        }

        public static Dictionary<float, float> ToFloatFloat(this IntPtr result)
        {
            string str = Marshal.PtrToStringAnsi(result);

            string[] splitStr = str.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<float, float> dictionary =
                      splitStr.Distinct().ToDictionary(s => float.Parse(s.Split('=')[0].Replace('.', ',')), s => float.Parse(s.Split('=')[1].Replace('.', ',')));

            return dictionary;
        }
    }
}
