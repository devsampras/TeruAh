using System.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CustomAuthentication
{
    public class CustomIdentity
    {
        public async Task<bool> ExecuteAuthentication(Microsoft.AspNetCore.Http.HttpContext current,string user, string password)
        {
            try
            {
                if(user=="admin" && password=="123456"){
                    var claims =new List<Claim>(){
                        new Claim(ClaimTypes.Name,"admin"),
                        new Claim(ClaimTypes.Email,"admin@test.it")
                    };
                    var identity=new ClaimsIdentity(claims,"MyCookieAuth");
                    ClaimsPrincipal principal=new ClaimsPrincipal(identity);

                   await current.SignInAsync("MyCookieAuth",principal);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}