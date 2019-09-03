using Microsoft.AspNetCore.Authentication;
using System;

namespace BikeManagementAPITests.Support.Authentication
{
    /// <summary>
    ///     Class that contains extension methods for the <see cref="AuthenticationBuilder"/>.
    /// </summary>
    public static class AuthenticationBuilderExtensions
    {
        /// <summary>
        ///     Add a custom handler to the authenticationbuilder that is used by the Authorize attribute.
        /// </summary>
        /// <param name="builder">Builder to which the test handler is added.</param>
        /// <param name="configureOptions">Authentication options.</param>
        /// <returns></returns>
        public static AuthenticationBuilder AddTestAuth(this AuthenticationBuilder builder, Action<TestAuthenticationOptions> configureOptions)
        {
            return builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>("Test scheme", "Test Auth", configureOptions);
        }
    }
}