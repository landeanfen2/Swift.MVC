using Swift.MVC.ViewEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC.MyRazor
{
    public class VelocityViewResult:ActionResult
    {
        public object Data { get; set; }
        public override void ExecuteResult(Routing.SwiftRouteData routeData)
        {
            //var filepath = AppDomain.CurrentDomain.BaseDirectory + @"Views\" + routeData.RouteValue["controller"];
            //这里必须是虚拟路径
            var velocity = new VelocityHelper(string.Format("~/Views/{0}/", routeData.RouteValue["controller"]));
            // 绑定实体model
            velocity.Put("model", Data);
            // 显示具体html
            HttpResponse response = HttpContext.Current.Response;
            response.ContentType = "text/html";
            velocity.Display(string.Format("{0}.cshtml", routeData.RouteValue["action"].ToString()));
        }
    }
}
