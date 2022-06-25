using Microsoft.AspNetCore.Http.Features;

namespace MiddlewareExample.Extensions
{
    public class AuthorizeExtension
    {
        public static bool IsAuthorize(HttpContext context)
        {
            if (context.Request != null && StringExtension.IsValid(context.Request.Path))
            {
                var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
                var attribute = endpoint?.Metadata.GetMetadata<PermissionAttribute>();

                if (attribute != null)
                {
                    string permissionType = attribute.Type;

                    if (permissionType.Equals("Admin"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
