using Swift.MVC.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC
{
    public class MvcRouteHandler:IRouteHandler
    {
        /// <summary>
        /// 返回处理当前请求的HttpHandler对象
        /// </summary>
        /// <param name="routeData">当前的请求的路由对象</param>
        /// <param name="context">当前请求的下文对象</param>
        /// <returns>处理请求的HttpHandler对象</returns>
        public System.Web.IHttpHandler GetHttpHandler(SwiftRouteData routeData, HttpContextBase context)
        {
            return new MvcHandler(routeData, context) ;
        }
    }
}
