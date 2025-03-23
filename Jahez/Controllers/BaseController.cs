using Microsoft.AspNetCore.Mvc;

namespace Jahez.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsJsonRequest => Request.Path.StartsWithSegments("/api", StringComparison.OrdinalIgnoreCase);
    }
}
