using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Infrastructure
{
    public static class CookieHelper
    {
        private const string cookieName = "MyCookie";

        public static bool isExistCookie() => HttpContext.Current.Request.Cookies["MyCookie"] != null;

        public static void AddCookie()
        {
            HttpCookie httpCookie = new HttpCookie(cookieName);
            httpCookie.Expires = DateTime.Now.AddDays(1);
            httpCookie.Value = Guid.NewGuid().ToString();
            HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public static string GetValueFromCookie() => HttpContext.Current.Request.Cookies[cookieName].Value;
    }
}