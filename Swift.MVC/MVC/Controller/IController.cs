using Swift.MVC.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swift.MVC
{
    public interface IController
    {
        void Execute(SwiftRouteData routeData);
    }
}
