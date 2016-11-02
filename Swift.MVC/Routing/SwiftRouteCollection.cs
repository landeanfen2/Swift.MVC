using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC.Routing
{
    public class SwiftRouteCollection
    {
        public SwiftRoute SwiftRoute { get; set; }

        public string Name { get; set; }

        //Global.asax里面配置路由规则和默认路由
        public void Add(string name, SwiftRoute route)
        {
            SwiftRoute = route;
            Name = name;
        }

        //通过上下文对象得到当前请求的路由表
        public SwiftRouteData GetRouteData(HttpContextBase context)
        {
            var swiftRouteData = new SwiftRouteData();
            //1.配置RouteHandler实例，这里的RouteHandler是在全局配置里面写进来的
            swiftRouteData.RouteHandler = SwiftRoute.RouteHandler;

            //2.获取当前请求的虚拟路径和说明
            var virtualPath = context.Request.AppRelativeCurrentExecutionFilePath.Substring(2) + context.Request.PathInfo;

            //3.先将默认路由配置写入当前请求的路由表
            //每次请求只能读取默认值，而不能覆盖默认值
            swiftRouteData.RouteValue = new Dictionary<string, object>() ;
            foreach (var key in this.SwiftRoute.DefaultPath)
            {
                swiftRouteData.RouteValue[key.Key] = key.Value;
            }

            //4.如果当前请求虚拟路径为空，则访问默认路由表。否则从当前请求的url里面去取当前的controller和action的名称
            if (!string.IsNullOrEmpty(virtualPath))
            {
                var arrTemplatePath = this.SwiftRoute.TemplateUrl.Split("{}/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var arrRealPath = virtualPath.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < arrTemplatePath.Length; i++)
                {
                    var realPath = arrRealPath.Length > i ? arrRealPath[i] : null;
                    if (realPath == null)
                    {
                        break;
                    }
                    swiftRouteData.RouteValue[arrTemplatePath[i]] = realPath;
                }
            }
            //5.去读当前请求的参数列表
            var querystring = context.Request.QueryString.ToString();
            if (string.IsNullOrEmpty(querystring))
            {
                return swiftRouteData;
            }
            var parameters = querystring.Split("&".ToArray(), StringSplitOptions.RemoveEmptyEntries) ;
            var oparam = new Dictionary<string, string>();
            foreach (var parameter in parameters)
            {
                var keyvalue = parameter.Split("=".ToArray());
                oparam[keyvalue[0]] = keyvalue[1];
            }
            swiftRouteData.RouteValue["parameters"] = oparam;
            return swiftRouteData;
        }
    }
}
