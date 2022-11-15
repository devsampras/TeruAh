using System.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CustomAuthentication
{
    public class CustomIdentity
    {
        public async Task<bool> ExecuteAuthentication(Microsoft.AspNetCore.Http.HttpContext current, string user, string password)
        {
            try
            {
                if (user == "admin" && password == "123456")
                {
                    var claims = new List<Claim>(){
                        new Claim(ClaimTypes.Name,"admin"),
                        new Claim(ClaimTypes.Email,"admin@test.it")
                    };
                    var identity = new ClaimsIdentity(claims, Misc.cookiename);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    await current.SignInAsync(Misc.cookiename, principal);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
    public static class Misc
    {
        internal static string cookiename{get;set;}=string.Empty;
        public static void AddSimpleAuthorization(this IServiceCollection s,string name="simpleauth")
        {
            cookiename=name;
            s.AddAuthentication(cookiename).AddCookie(cookiename, options =>
            {
                options.Cookie.Name = cookiename;
                options.LoginPath = "/Home/Login";
            });
        }
    }
}