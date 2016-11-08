using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC.MyRazor
{
    public class MyViewResult : ActionResult
    {
        public object Data { get; set; }

        public override void ExecuteResult(Routing.SwiftRouteData routeData)
        {
            HttpResponse response = HttpContext.Current.Response;

            response.ContentType = "text/html";

            //取当前view页面的物理路径
            var path = AppDomain.CurrentDomain.BaseDirectory + "Views/" + routeData.RouteValue["controller"] + "/" + routeData.RouteValue["action"] + ".html";
            var templateData = string.Empty;
            using (var fsRead = new FileStream(path, FileMode.Open))
            {
                int fsLen = (int)fsRead.Length;
                byte[] heByte = new byte[fsLen];
                int r = fsRead.Read(heByte, 0, heByte.Length);
                templateData = System.Text.Encoding.UTF8.GetString(heByte);
            }
            response.Write(templateData);
        }
    }
}
