using System.Security.Claims;
using System.Security.Principal;

namespace Becky.Web.Helpers
{
    public static class IdentityExtensions
    {
        public static string GetProfilePictureUrl(this IIdentity identity)
        {
            var obj = ((ClaimsIdentity)identity).FindFirst("ProfilePictureUrl");

            return obj == null ? string.Empty : obj.Value;
        }

        public static string GetFullName(this IIdentity identity)
        {
            var obj = ((ClaimsIdentity)identity).FindFirst("FullName");

            return obj == null ? string.Empty : obj.Value;
        }
    }
}