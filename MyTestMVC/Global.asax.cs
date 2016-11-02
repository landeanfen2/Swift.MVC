using Swift.MVC;
using Swift.MVC.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MyTestMVC
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            var defaultPath = new Dictionary<string, object>();
            defaultPath.Add("controller", "Home");
            defaultPath.Add("action", "Index");
            defaultPath.Add("id", null);
            defaultPath.Add("namespaces", "MyTestMVC.Controllers");
            defaultPath.Add("assembly", "MyTestMVC");

            SwiftRouteTable.Routes.Add("defaultRoute", new SwiftRoute("{controller}/{action}/{id}", defaultPath, new MvcRouteHandler()));
            //RouteTable.Routes.Add("defaultRoute", new Route("{controller}/{action}/{id}", new RouteValueDictionary(new { controller = "Home", action = "Index", id = "", namespaces = "MyTestMVC.Controllers", assembly = "MyTestMVC" }), new Swift.MVC.MvcRouteHandler()));
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{

        //}

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        //protected void Application_AuthenticateRequest(object sender, EventArgs e)
        //{

        //}

        //protected void Application_Error(object sender, EventArgs e)
        //{

        //}

        //protected void Session_End(object sender, EventArgs e)
        //{

        //}

        //protected void Application_End(object sender, EventArgs e)
        //{

        //}
    }
}