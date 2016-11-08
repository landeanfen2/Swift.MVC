using Swift.MVC.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.MVC.MyRazor
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(SwiftRouteData routeData);
    }
}
