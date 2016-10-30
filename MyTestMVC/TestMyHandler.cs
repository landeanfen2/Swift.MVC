using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestMVC
{
    public class TestMyHandler:IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("从asex页面进来");

            //throw new NotImplementedException();
        }
    }
}