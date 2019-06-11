using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.DisplayManagement.Entities;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.DisplayManagement.Views;
using OrchardCore.Settings;
using TheBootstrapTheme.OrchardCore.ViewModels;

namespace TheBootstrapTheme.OrchardCore
{
    public class BootstrapSettingsDisplayDriver : SectionDisplayDriver<ISite, BootstrapSettings>
    {
        public const string GroupId = "bootstrap";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthorizationService _authorizationService;

        public BootstrapSettingsDisplayDriver(
            IHttpContextAccessor httpContextAccessor,
            IAuthorizationService authorizationService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authorizationService = authorizationService;
        }

        public override async Task<IDisplayResult> EditAsync(BootstrapSettings settings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageBootstrapSettings))
            {
                return null;
            }

            return Initialize<BootstrapSettingsViewModel>("BootstrapSettings_Edit", model =>
                {
                    model.Background = settings.Background;
                }).Location("Content:3").OnGroup(GroupId);
        }

        public override async Task<IDisplayResult> UpdateAsync(BootstrapSettings settings, BuildEditorContext context)
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (!await _authorizationService.AuthorizeAsync(user, Permissions.ManageBootstrapSettings))
            {
                return null;
            }

            if (context.GroupId == GroupId)
            {
                var model = new BootstrapSettingsViewModel();

                await context.Updater.TryUpdateModelAsync(model, Prefix);

                settings.Background = model.Background;
            }

            return await EditAsync(settings, context);
        }
    }
}
