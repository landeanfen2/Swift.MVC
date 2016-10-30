using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Swift.MVC
{
    //控制器创建工厂
    public interface IControllerFactory
    {
        //创建控制器
        IController CreateController(RequestContext requestContext, string controllerName);
        
        //释放控制器
        void ReleaseController(IController controller);
    }
}
