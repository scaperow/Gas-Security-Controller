using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace GSC
{
    public class HexCode
    {

        public static byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        public static string ByteToHexString(string s)
        {
            string range = "0123456789ABCDEF";
            char[] hex = s.ToCharArray();
            byte[] bytes = new byte[s.Length / 2];
            int n;
            for (int i = 0; i < bytes.Length; i++)
            {
                n = range.IndexOf(hex[2 * i]) * 16;
                n += range.IndexOf(hex[2 * i + 1]);
                bytes[i] = (byte)(n & 0xff);
            }
            return Encoding.Unicode.GetString(bytes);
        }

        public static string Data_Asc_Hex(ref string Data)
        {
            //first take each charcter using substring.
            //then convert character into ascii.
            //then convert ascii value into Hex Format
            string sValue;
            string sHex = "";
            while (Data.Length > 0)
            {
                sValue = Conversion.Hex(Strings.Asc(Data.Substring(0, 1).ToString()));
                Data = Data.Substring(1, Data.Length - 1);
                sHex = sHex + sValue;
            }
            return sHex;
        }
    }

}
