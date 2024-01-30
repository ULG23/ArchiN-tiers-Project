using Localization.Resources.AbpUi;
using JeBalance.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JeBalance.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JeBalance;

[DependsOn(
    typeof(JeBalanceApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class JeBalanceHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();

        Configure<AbpExceptionHandlingOptions>(options =>
        {
            options.SendExceptionsDetailsToClients = true;
        });

    //    var configuration = context.Services.GetConfiguration();

    //    context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    //.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    //{
    //    var settings = new JwtSettings();
    //    configuration.Bind(AppSettingsKey.Jwt, settings);

    //    options.Audience = settings.Audience;
    //    options.ClaimsIssuer = settings.Issuer;

    //    options.TokenValidationParameters.ValidAudience = settings.Audience;
    //    options.TokenValidationParameters.ValidateAudience = settings.ValidateAudience;
    //    options.TokenValidationParameters.ValidateIssuer = settings.ValidateIssuer;
    //    options.TokenValidationParameters.ValidIssuer = settings.Issuer;
    //    options.TokenValidationParameters.ValidateLifetime = settings.ValidateLifetime;
    //    options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.IssuerSigningKey));
    //});
        
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<JeBalanceResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }


}
