using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestMVC
{
    public class TestMyModule2:IHttpModule
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
            app.Context.Response.Write("请求拦截结束  ");
        }

        void app_BeginRequest(object sender, EventArgs e)
        {
            var app = (HttpApplication)sender;
            app.Context.Response.Write("请求拦截开始  ");

            //请求拦截的处理逻辑....
        }

        //public virtual void PostResolveRequestCache(HttpContextBase context)
        //{
        //    //1.传入当前上下文对象，得到与当前请求匹配的RouteData对象
        //    RouteData routeData = this.RouteCollection.GetRouteData(context);
        //    if (routeData != null)
        //    {
        //        //2.从RouteData对象里面得到当前的RouteHandler对象
        //        IRouteHandler routeHandler = routeData.RouteHandler;
        //        if (routeHandler == null) throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, SR.GetString("UrlRoutingModule_NoRouteHandler"), new object[0]));
        //        if (!(routeHandler is StopRoutingHandler))
        //        {
        //            //3.根据HttpContext和RouteData得到RequestContext对象
        //            RequestContext requestContext = new RequestContext(context, routeData);
        //            context.Request.RequestContext = requestContext;

        //            //4.根据RequestContext对象得到处理当前请求的HttpHandler（MvcHandler）。
        //            IHttpHandler httpHandler = routeHandler.GetHttpHandler(requestContext);
        //            if (httpHandler == null)
        //            {
        //                object[] args = new object[] { routeHandler.GetType() };
        //                throw new InvalidOperationException(string.Format(CultureInfo.CurrentUICulture, SR.GetString("UrlRoutingModule_NoHttpHandler"), args));
        //            }
        //            if (httpHandler is UrlAuthFailureHandler)
        //            {
        //                if (!FormsAuthenticationModule.FormsAuthRequired) throw new HttpException(0x191, SR.GetString("Assess_Denied_Description3"));
        //                UrlAuthorizationModule.ReportUrlAuthorizationFailure(HttpContext.Current, this);
        //            }
        //            else
        //                //5.请求转到HttpHandler进行处理（进入到ProcessRequest方法）
        //                context.RemapHandler(httpHandler);
        //        }
        //    }
        //}

 

 

    }
}