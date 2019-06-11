using System.Collections.Generic;
using OrchardCore.Security.Permissions;

namespace TheBootstrapTheme.OrchardCore
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission ManageBootstrapSettings = new Permission("ManageBootstrapSettings", "Manage Bootstrap settings");

        public IEnumerable<Permission> GetPermissions()
        {
            return new[] { ManageBootstrapSettings };
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Administrator",
                    Permissions = new[] { ManageBootstrapSettings }
                }
            };
        }
    }
}