using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace UncleProductTracking.Common.Helpers.Text
{
    public class TextHelper
    {

        /// <summary>
        /// String içeririsinde ki HTML kodlarını temizler.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
    }
}
