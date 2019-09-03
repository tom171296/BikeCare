using Microsoft.AspNetCore.Authentication;
using System;
using System.Security.Claims;

namespace BikeManagementAPITests.Support.Authentication
{
    /// <summary>
    ///     Class that contains all the test authentication options
    /// </summary>
    public class TestAuthenticationOptions : AuthenticationSchemeOptions
    {
        public virtual ClaimsIdentity Identity { get; } = new ClaimsIdentity(new Claim[]
        {
            new Claim("test", "test", nameof(String), "blognet.integrationtest.eu.auth0.com")
        }, "test");
    }
}