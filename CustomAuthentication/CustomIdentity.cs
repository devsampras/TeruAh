using System.Collections;
using System.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace CustomAuthentication
{
    public static class CustomIdentity
    {
        public static async Task<bool> SignIn(this Microsoft.AspNetCore.Http.HttpContext current, string token,bool remember)
        {
            try
            {
                
                    var claims = new List<Claim>(){
                        new Claim("token",token)
                    };
                    var identity = new ClaimsIdentity(claims, Misc.cookiename);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    var authProperties=new AuthenticationProperties {
                        IsPersistent=remember
                    };

                    await current.SignInAsync(Misc.cookiename, principal);
                
            }
            catch
            {
                return false;
            }
            return true;
        }
         public static async Task<bool> SignOut(this Microsoft.AspNetCore.Http.HttpContext current){
            
            await current.SignOutAsync(Misc.cookiename);
            return true;
         }
    }
    public static class Misc
    {
        internal static string cookiename{get;set;}=string.Empty;
        public static IServiceCollection AddSimpleAuthentication(this IServiceCollection s,string name="simpleauth")
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("name cannot be null, empty or whitespace");
            cookiename=name;
            s.AddAuthentication(cookiename).AddCookie(cookiename, options =>
            {
                options.Cookie.Name = cookiename;
                options.LoginPath = "/Home/Login";
            });

            return s;
        }
        public static IServiceCollection AddCustomAuthorizationHandler<T>(this IServiceCollection s){
            
            return s;
        }
    }
}