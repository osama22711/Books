using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients { get; } = new List<Client>
        {
            // Define your clients here.
        };

        public static IEnumerable<IdentityResource> IdentityResources { get; } = new List<IdentityResource>
        {
            // Define your identity resources here.
        };

        public static IEnumerable<ApiScope> ApiScopes { get; } = new List<ApiScope>
        {
            // Define your API scopes here.
        };

        public static IEnumerable<ApiResource> ApiResources { get; } = new List<ApiResource>
        {
            // Define your API resources here.
        };

        public static List<TestUser> Users { get; } = new List<TestUser>
        {
            // Define your test users here.
        };
    }
}
