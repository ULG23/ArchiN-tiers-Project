using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Volo.Abp.Timing;
using System.Security.Claims;
using JeBalance.Models;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using static Volo.Abp.Identity.IdentityPermissions;
using JeBalance.Settings;
using System.Security.Cryptography;

namespace JeBalance.Authorization
{ 
    public class GenerateJwtTokenAppService : ApplicationService, IGenerateJwtTokenAppService
    {

        private readonly IConfiguration configuration;


        public GenerateJwtTokenAppService(IConfiguration _config)
		{
            configuration = _config;
		}

        private async Task<AccesToken> GenerateToken(string[] roles)
        {
            var settings = new JwtSettings();
            configuration.Bind(AppSettingsKey.Jwt, settings);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.IssuerSigningKey));
            var signingcredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Mise de la date en utc pour éviter que les différents services soient sur un fuseau différent
            var issuedDateTime = DateTime.UtcNow;
            var lifeTime = settings.TokenAvailabilityDelay;

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, new Guid().ToString()),
                new Claim(ClaimDefinitions.ClaimTypes.IssuedDateTime, issuedDateTime.ToString(ClaimDefinitions.ClaimTypes.IssuedDateTimeFormat)),
                new Claim(ClaimDefinitions.ClaimTypes.LifeTime, lifeTime.ToString()),
            };

          
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var token = new JwtSecurityToken(settings.Issuer,
                settings.Audience,
                claims,
                expires: issuedDateTime.AddSeconds(lifeTime),
                signingCredentials: signingcredentials);

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);

            return new AccesToken
            {
                Token = accessToken,
                IssuedDateTime = issuedDateTime,
                Lifetime = lifeTime,
            };
        }

        // Endpoints permettant de générer des tokens d'une durée de 2h, avec les différents rôles
        public async Task<string> GetTokenWithAdminRole()
        {
            var token = await GenerateToken(new string[] { "admin" }).ConfigureAwait(false);
            return token.Token; 
        }

        public async Task<string> GetTokenWithAdminFiscaleRole()
        {
            var token = await GenerateToken(new string[] { "adminFiscale" }).ConfigureAwait(false);
            return token.Token;
        }

        public async Task<string> GetTokenWithBothAdminRole()
        {
            var token = await GenerateToken(new string[] { "admin", "adminFiscale" }).ConfigureAwait(false);
            return token.Token;
        }
    }
}

