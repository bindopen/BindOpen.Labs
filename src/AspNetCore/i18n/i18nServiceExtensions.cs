using BindOpen.Labs.i18n;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// This static class contains i18n extensions.
    /// </summary>
    public static class I18nServiceExtensions
    {
        /// <summary>
        /// Configures the specified .Net core service collection.
        /// </summary>
        /// <param name="services">The service collection to consider.</param>
        public static void ConfigureBindOpenLocalization(this IServiceCollection services)
        {
            // we add the required singletons

            services.AddSingleton<IStringLocalizerFactory, CustomStringLocalizerFactory>();
            services.AddSingleton<IStringLocalizer, CustomStringLocalizer>(
                p => (CustomStringLocalizer)p.GetService<IStringLocalizerFactory>().Create(null, null));

            // we specify the localization resource path (if we use embeded resources one day)

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // we configure request location options

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: i18nDefaultSettings.__DefaultCulture, uiCulture: i18nDefaultSettings.__DefaultCulture);

                // we defines the supported cultures (insuring ourselves that the default culture is included)

                if (!i18nDefaultSettings.__SupportedCultures.Any(p => p.Name.Equals(i18nDefaultSettings.__DefaultCulture, StringComparison.InvariantCultureIgnoreCase)))
                {
                    i18nDefaultSettings.__SupportedCultures.Add(new CultureInfo(i18nDefaultSettings.__DefaultCulture));
                }
                options.SupportedCultures = options.SupportedUICultures = i18nDefaultSettings.__SupportedCultures;

                options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(context =>
                {
                    // we retrieve the language from query string first
                    // then (if not existing) from header

                    var lang = context.GetHttpContextUICulture(options.DefaultRequestCulture.UICulture?.Name);

                    return Task.FromResult(new ProviderCultureResult(lang));
                }));
            });
        }
    }
}