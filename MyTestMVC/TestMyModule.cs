using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestMVC
{
    public class TestMyModule:IHttpModule
    {
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication app)
        {
            //事件注册
            app.BeginRequest += app_BeginRequest;
            app.EndRequest += app_EndRequest;
        }

        void app_EndRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            app.Context.Response.Write("功能检查结束  ");
        }

        void app_BeginRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            app.Context.Response.Write("功能检查开始  ");

            //功能检查的处理逻辑...
        }
    }
}