using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.MVC
{
    public abstract class Controller:ControllerBase,IDisposable
    {

        public override void Execute(System.Web.Routing.RequestContext requestContext)
        {
            //反射得到Action方法
            Type type = this.GetType();
            string actionName = requestContext.RouteData.GetRequiredString("action");
            System.Reflection.MethodInfo mi = type.GetMethod(actionName);

            //执行该Action方法
            mi.Invoke(this, new object[] { });//调用方法
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
