using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BikeManagementAPITests.Support.Authentication
{
    /// <summary>
    ///     Custom authentication handler for test purpose.
    /// </summary>
    public class TestAuthenticationHandler : AuthenticationHandler<TestAuthenticationOptions>
    {
        private readonly ILogger<TestAuthenticationHandler> _logger;

        public static AuthenticationState ValidationState { get; internal set; } = AuthenticationState.Invalid;

        /// <summary>
        /// Creates a new instance of <see cref="TestAuthenticationHandler"/>
        /// </summary>
        /// <param name="options">Provided options</param>
        /// <param name="logger">Logger factory used to create logger</param>
        /// <param name="encoder"></param>
        /// <param name="clock">System clock</param>
        public TestAuthenticationHandler(IOptionsMonitor<TestAuthenticationOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            _logger = logger.CreateLogger<TestAuthenticationHandler>();
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            _logger.LogDebug("new authentication request received");

            var authenticationTicket = new AuthenticationTicket(
                new ClaimsPrincipal(Options.Identity),
                new AuthenticationProperties(),
                "Test Scheme");

            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }

        /// <summary>
        ///     Called on scenario start to reset the test handler
        /// </summary>
        public static void Reset()
        {
            ValidationState = AuthenticationState.Invalid;
        }
    }
}