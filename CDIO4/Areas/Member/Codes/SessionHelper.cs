using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDIO4.Areas.Member.Codes
{
    public class SessionHelper
    {
        public static void SetSession (UserSession session)
        {
            HttpContext.Current.Session["DangNhapSession"] = session;
        }

        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["DangNhapSession"];
            if(session == null)
            {
                return null;
            }
            else
            {
                return session as UserSession;
            }
        }
    }
}