﻿using System;

namespace TCPNetwork.Utils
{
    public static class CommandUtils
    {

        public static byte[] AddCommandLength(byte[] commandBytes)
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

        public static byte[] ConcaTo(this byte[] first, byte[] second) => ConcatByteArrays(first, second);

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


    }
}
