using System;
using System.Text;

namespace MyToolkits.Unitities.Conversion
{
    public class Conversion
    {
        /// <summary>
        /// 字符串转Hex字符串,"1234"->"31 32 33 34"
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        public static string String2Hex(string str1)
        {
            Byte[] data = Encoding.Default.GetBytes(str1);
            if (str1 != null)
            {
                return BitConverter.ToString(data).Replace("-", " ");
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Hex字符串转字符串,"31 32 33 34"->"1234"
        /// </summary>
        /// <param name="Hex"></param>
        /// <returns></returns>
        public static string Hex2String(string Hex)
        {

            if (Hex != null)
            {
                byte[] data = HexString2Byte(Hex);
                return Encoding.Default.GetString(data);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 16进制格式string 转byte[],"31 32 33 34"->{0x31,0x32,0x33,0x34}
        /// </summary>
        /// <param name="Hex"></param>
        /// <returns></returns>
        public static byte[] HexString2Byte(string Hex)
        {
            string str1 = Hex.Replace(" ", "");
            int length = 0;
            if (length % 2 == 0)
            {
                length = str1.Length / 2;
            }
            else
            {
                length = str1.Length / 2 + 1;
                str1 = str1.Insert(length - 1, "0");
                Console.WriteLine(str1);
            }
            byte[] data = new byte[length];
            for (int i = 0; i < length; i++)
            {
                data[i] = Convert.ToByte(str1.Substring(i * 2, 2), 16);
            }
            return data;
        }
        /// <summary>
        /// byte[]转16进制string,{0x31,0x32,0x33,0x34}->"31 32 33 34"
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Byte2HexString(byte[] data)
        {
            if (data != null)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)

                {

                    sb.Append(data[i].ToString("X2") + " ");

                }
                string hexString = sb.ToString();
                return hexString;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// byte[]转string,{0x31,0x32,0x33,0x34}->"1234"
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Byte2String(byte[] data)
        {
            return System.Text.Encoding.Default.GetString(data);
        }
        /// <summary>
        /// byte数组合并到Int
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static int Byte2Int(byte[] data, int startindex = 0, int stopindext = 0)
        {
            var value = data;
            Array.Reverse(value);
            return BitConverter.ToInt32(data, startindex);
        }
        /// <summary>
        /// Conversion order
        /// _LOW_HIGH:Lower byte first, higher byte last
        /// _HIGH_LOWH:igher byte first, lower byte last
        /// </summary>
        public enum Order { _LOW_HIGH, _HIGH_LOW }
        /// <summary>
        /// AryByteTo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="offset"></param>
        /// <param name="length"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public static T AryByteTo<T>(byte[] data, int startindex = 0, int length = 4, Order order = Order._LOW_HIGH)
        {
            byte[] value = new byte[length];
            Array.Copy(data, startindex, value, 0, length);
            byte[] valuereverse = value;
            Array.Reverse(valuereverse);
            object obj = 11;
            switch (typeof(T).Name)
            {
                case "int":
                case "Int32":
                    {
                        if (order == Order._LOW_HIGH)
                        {
                            return (T)(object) BitConverter.ToInt32(valuereverse, startindex) ;

                        }
                        else
                        {
                            return (T)(object)BitConverter.ToInt32(value, startindex);
                        }
                        //break;
                    }
                default: break;
            }
            return (T)obj;
        }
    }
}
