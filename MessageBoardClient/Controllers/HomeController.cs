using Microsoft.AspNetCore.Mvc;

namespace MessageBoardClient.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
