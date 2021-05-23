﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PdfToSvg.Common
{
    internal static class StableID
    {
        public static string Generate(string prefix, IEnumerable inputs)
        {
            var sb = new StringBuilder();

            if (inputs != null)
            {
                foreach (var input in inputs)
                {
                    if (input != null)
                    {
                        if (input is IFormattable formattable)
                        {
                            sb.Append(formattable.ToString(null, CultureInfo.InvariantCulture));
                        }
                        else
                        {
                            sb.Append(input.ToString());
                        }
                    }
                }
            }

            return Generate(prefix, sb.ToString());
        }

        public static string Generate(string prefix, params object[] inputs)
        {
            return Generate(prefix, (IEnumerable)inputs);
        }

        public static string Generate(string prefix, string input)
        {
            using (var sha1 = SHA1.Create())
            {
                const string Chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

                var inputBytes = Encoding.Unicode.GetBytes(input);
                var hashBytes = sha1.ComputeHash(inputBytes);

                var result = new char[7];
                prefix.CopyTo(0, result, 0, prefix.Length);

                for (var i = prefix.Length; i < result.Length; i++)
                {
                    result[i] = Chars[hashBytes[i] % Chars.Length];
                }

                return new string(result);
            }
        }
    }
}
