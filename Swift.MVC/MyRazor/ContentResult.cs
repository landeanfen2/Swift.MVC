using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC.MyRazor
{
    public class ContentResult:ActionResult
    {
        //页面内容
        public string Content { get; set; }

        //编码方式
        public Encoding ContentEncoding { get; set; }

        //response返回内容的格式
        public string ContentType { get; set; }

        public override void ExecuteResult(Routing.SwiftRouteData routeData)
        {
            HttpResponse response = HttpContext.Current.Response;

            if (!string.IsNullOrEmpty(ContentType))
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "text/html";
            }
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            if (Content != null)
            {
                response.Write(Content);
            }
        }
    }
}
