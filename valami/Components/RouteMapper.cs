using System.Web.Http;
using DotNetNuke.Web.Api;

namespace valami.valami.Components
{
    public class RouteMapper : IServiceRouteMapper
    {
        public void RegisterRoutes(IMapRoute mapRouteManager)
        {
            mapRouteManager.MapHttpRoute(
                moduleFolderName: "valami",
                routeName: "default",
                url: "{controller}/{action}",
                defaults: new { date = RouteParameter.Optional },
                namespaces: new[] { "valami.valami.Controllers" }
            );
        }
    }
}
