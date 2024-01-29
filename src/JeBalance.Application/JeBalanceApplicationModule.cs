using System.Text;
using JeBalance.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace JeBalance;

[DependsOn(
    typeof(JeBalanceDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(JeBalanceApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class JeBalanceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<JeBalanceApplicationModule>();
        });


        var configuration = context.Services.GetConfiguration();

        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        var settings = new JwtSettings();
        configuration.Bind(AppSettingsKey.Jwt, settings);

        options.Audience = settings.Audience;
        options.ClaimsIssuer = settings.Issuer;

        options.TokenValidationParameters.ValidAudience = settings.Audience;
        options.TokenValidationParameters.ValidateAudience = settings.ValidateAudience;
        options.TokenValidationParameters.ValidateIssuer = settings.ValidateIssuer;
        options.TokenValidationParameters.ValidIssuer = settings.Issuer;
        options.TokenValidationParameters.ValidateLifetime = settings.ValidateLifetime;
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.IssuerSigningKey));
    });

    }
}
