using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Authentication;

public class HasPermissionAttribute: AuthorizeAttribute
{
    public HasPermissionAttribute(Permissions permission)
        : base(policy: permission.ToString())
    {
        
    }   
}