

using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Authentication{
    public class CustomAuthenticationHandler : AuthenticationHandler<CustomSchemeOptions>
    {
        private readonly IUserRepository _userRepository;
        public CustomAuthenticationHandler(IOptionsMonitor<CustomSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock,IUserRepository userRepository) : base(options, logger, encoder, clock)
        {
            _userRepository=userRepository;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            throw new NotImplementedException();
        }
    }
    public class CustomSchemeOptions
        : AuthenticationSchemeOptions
    { }
}