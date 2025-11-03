using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuyTogether.Web.Controllers
{
    [Authorize]
    public class OrdersController : Controller {  }
}
