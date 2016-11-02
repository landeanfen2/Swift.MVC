using Swift.MVC.Routing;
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
        public MvcHandler()
        { }

        public HttpContextBase SwiftContext { get; set; }
        public SwiftRouteData SwiftRouteData { get; set; }
        //通过构造函数将两个对象传过来，替代了原来RequestContext的作用
        public MvcHandler(SwiftRouteData routeData, HttpContextBase context)
        {
            SwiftRouteData = routeData;
            SwiftContext = context;
        }

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

            //1.从当前的RouteData里面得到请求的控制器名称
            string controllerName = SwiftRouteData.RouteValue["controller"].ToString();

            //2.得到控制器工厂
            IControllerFactory factory = new SwiftControllerFactory();

            //3.通过默认控制器工厂得到当前请求的控制器对象
            IController controller = factory.CreateController(SwiftRouteData, controllerName);
            if (controller == null)
            {
                return;
            }

            try
            {
                //4.执行控制器的Action
                controller.Execute(SwiftRouteData);
            }
            catch
            {

            }
            finally
            {
                //5.释放当前的控制器对象
                factory.ReleaseController(controller);
            }

        }
    }
}
