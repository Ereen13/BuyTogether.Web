using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Authorization;

[Authorize(Roles = "Admin")]
public class AdminController1 : Controller
{
    public IActionResult Index() => View();
}
