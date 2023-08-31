using CustomAuthentication;
using Data;
using Data.DS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Teruah.Controllers
{
    public class HomeController : Controller
    {
        
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public async void Logout()
        {
            await HttpContext.SignOut();
            Response.Redirect("~/");
        }
        [HttpPost]
        public async Task<ActionResult> Login(string user,string password)
        {
            Console.WriteLine($"name: {user} password:{password}");
            try{
              if(user=="user" && password=="123456"){
              await HttpContext.SignIn(user+password,true);
            Response.Redirect("/");  
            }
            }catch{
            
            }
            
            return View(new {msg="Username o Password non corretti"});
        }

        public ActionResult Parola(){
            return View(new ParolaService().GetFullGroupsIndex());
        }
        
    }
}