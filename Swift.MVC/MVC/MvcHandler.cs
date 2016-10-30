using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC
{
    public class MvcHandler : IHttpHandler
    {
        public virtual bool IsReusable
        {
            get { return false; }
        }

        public virtual void ProcessRequest(HttpContext context)
        {
            //写入MVC的版本到HttpHeader里面
            //AddVersionHeader(httpContext);
            //移除参数
            //RemoveOptionalRoutingParameters();

            //1.从上下文的Request.RequestContext中取到RouteData对象。这里和UrlRoutingModule里面的context.Request.RequestContext = requestContext;对应。
            var routeData = context.Request.RequestContext.RouteData;

            //2.从当前的RouteData里面得到请求的控制器名称
            string controllerName = routeData.GetRequiredString("controller");

            //3.得到控制器工厂
            IControllerFactory factory = new SwiftControllerFactory();

            //4.通过默认控制器工厂得到当前请求的控制器对象
            IController controller = factory.CreateController(context.Request.RequestContext, controllerName);
            if (controller == null)
            {
                return;
            }

            try
            {
                //5.执行控制器的Action
                controller.Execute(context.Request.RequestContext);
            }
            catch { 
            
            }
            finally
            {
                //6.释放当前的控制器对象
                factory.ReleaseController(controller);
            }

        }
    }
}
