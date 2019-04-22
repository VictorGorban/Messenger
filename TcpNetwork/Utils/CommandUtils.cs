using Newtonsoft.Json;
using System;

namespace TCPNetwork.Utils
{
    public static class CommandUtils
    {
        public static byte[] PrependLengthBytes(byte[] commandBytes)
        {
            return ConcatByteArrays(BitConverter.GetBytes(commandBytes.Length), commandBytes);
        }

        public static byte[] ConcatByteArrays(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);
            return ret;
        }

        public static byte[] ConcatTo(this byte[] first, byte[] second) => ConcatByteArrays(first, second);

        public static int BytesToInt(byte[] bytesArray)
        {
            return BitConverter.ToInt32(bytesArray, 0);
        }

        public static byte[] GetBytes(this string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(this byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        public static string EncryptSHA512(this string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        #region Serialization
        public static T JsonDeserialize<T>(this byte[] bytes)
        {
            var jsonString = bytes.GetString();
            var Deserialized = JsonConvert.DeserializeObject<T>(jsonString);

            return Deserialized;
        }

        public static byte[] JsonSerializeToBytes<T>(this T obj)
        {
            var jsonString = JsonConvert.SerializeObject(obj);
            var bytes = jsonString.GetBytes();
            return bytes;
        }

        #endregion
    }
}
