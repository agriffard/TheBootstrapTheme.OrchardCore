using OrchardCore.ResourceManagement;

namespace TheBootstrapTheme.OrchardCore
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(IResourceManifestBuilder builder)
        {
            var manifest = builder.Add();

            manifest
                .DefineStyle("TheBootstrapTheme-bootstrap-oc")
                .SetUrl("~/TheBootstrapTheme/css/bootstrap-oc.min.css", "~/TheBootstrapTheme/css/bootstrap-oc.css")
                .SetVersion("1.0.0");

            manifest
                .DefineStyle("navbar-top-fixed")
                .SetUrl("~/TheBootstrapTheme/css/navbar-top-fixed.css")
                .SetVersion("1.0.0");
            
            manifest
                .DefineStyle("sticky-footer")
                .SetUrl("~/TheBootstrapTheme/css/sticky-footer.css")
                .SetVersion("1.0.0");				
        }
    }
}
