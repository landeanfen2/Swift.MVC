using MyTestMVC.Models;
using Swift.MVC;
using Swift.MVC.MyRazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTestMVC.Controllers
{
    public class MyViewController:Controller
    {
        public ActionResult ContentIndex()
        {
            return Content("Hello", "text/html", System.Text.Encoding.Default);
        }

        public ActionResult JsonIndex()
        {
            var lstUser = new List<User>();
            lstUser.Add(new User() { Id = 1, UserName = "Admin", Age = 20, Address = "北京", Remark = "超级管理员" });
            lstUser.Add(new User() { Id = 2, UserName = "张三", Age = 37, Address = "湖南", Remark = "呵呵" });
            lstUser.Add(new User() { Id = 3, UserName = "王五", Age = 32, Address = "广西", Remark = "呵呵" });
            lstUser.Add(new User() { Id = 4, UserName = "韩梅梅", Age = 26, Address = "上海", Remark = "呵呵" });
            lstUser.Add(new User() { Id = 5, UserName = "呵呵", Age = 18, Address = "广东", Remark = "呵呵" });
            return Json(lstUser, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewIndex()
        {
            //return MyView();
            //return RazorEngineView(new { Name = "小明", Age = 16, School = "育才高中" });
            return VelocityView(new { Name = "小明", Age = 16, School = "育才高中" });
        }
    }
}