using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Swift.MVC.MyRazor
{
    public class RazorEngineViewResult:ActionResult
    {
        public object Data { get; set; }

        public override void ExecuteResult(Routing.SwiftRouteData routeData)
        {
            var filepath = AppDomain.CurrentDomain.BaseDirectory + @"Views\" + routeData.RouteValue["controller"] + "\\" + routeData.RouteValue["action"] + ".html";
            var fileContent = Engine.Razor.RunCompile(File.ReadAllText(filepath), filepath, null, Data);
            HttpResponse response = HttpContext.Current.Response;

            response.ContentType = "text/html";
            response.Write(fileContent);
            
        }



        //string template = "姓名： @Model.Name, 年龄：@Model.Age, 学校：@Model.School";
        //var result = Engine.Razor.RunCompile(template, "templateKey", null,
        //                                    new { Name = "小明", Age = 16, School = "育才高中" });

        //var filepath = AppDomain.CurrentDomain.BaseDirectory + @"Views\" + routeData.RouteValue["controller"] + "\\" + routeData.RouteValue["action"] + ".html";
        //var fileContent = Engine.Razor.RunCompile(new LoadedTemplateSource(template, filepath), "templateKey2", null,
        //                                          new { Name = "小明", Age = 16, School = "育才高中" });
           //string template = "Hello @Model.Name, welcome to RazorEngine!";
           //string templateFile = "C:/mytemplate.cshtml";
           //var result = Engine.Razor.RunCompile(new LoadedTemplateSource(template, templateFile), "templateKey", null, new { Name = "World" });
        
    }
}
