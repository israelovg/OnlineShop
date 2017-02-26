using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Extentions
{
    public static class StringExtentions
    {
        public static string LimitTo(this string data, int length)
        {
            return (data == null || data.Length < length)
              ? data
              : data.Substring(0, length)+"...";
        }
    }
}