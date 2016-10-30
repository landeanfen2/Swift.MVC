using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestMVC
{
    /// <summary>
    /// TestHttpHandler 的摘要说明
    /// </summary>
    public class TestHttpHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            var username = context.Request.QueryString["username"];
            var password = context.Request.QueryString["password"];
            if (username == "admin" && password == "admin")
            {
                context.Response.Write("用户admin登录成功");
            }
            else
            {
                context.Response.Write("用户名或者密码错误");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}