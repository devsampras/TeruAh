using CustomAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Teruah.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            Console.WriteLine($"IsAuthentcicated: {HttpContext.User.Identity.IsAuthenticated}");
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string user,string password)
        {
            Console.WriteLine($"name: {user} password:{password}");
            var i=new CustomIdentity();
            var res=await i.ExecuteAuthentication(HttpContext,user,password);
            if(!res) throw new Exception("login errata");
            Response.Redirect("/");
            return View();
        }
    }
}