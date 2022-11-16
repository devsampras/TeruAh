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
            Console.WriteLine($"Token: {HttpContext.User.Claims.SingleOrDefault(x=>x.Type=="token").Value}");
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOut();
            Response.Redirect("~/");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string user,string password)
        {
            Console.WriteLine($"name: {user} password:{password}");
            try{
              if(user=="user" && password=="123456"){
              await HttpContext.SignIn(user+password,false);
            Response.Redirect("/");  
            }
            }catch{
            
            }
            
            return View(new {msg="Username o Password non corretti"});
        }
    }
}