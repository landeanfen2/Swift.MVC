using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.MVC.Routing
{
    public class SwiftRouteTable
    {
        //静态构造函数，约束这个静态对象是一个不被释放的全局变量
        static SwiftRouteTable()
        {
            routes = new SwiftRouteCollection();
        }
        private static SwiftRouteCollection routes;
        public static SwiftRouteCollection Routes
        {
            get
            {
                return routes;
            }
        }
    }
}
