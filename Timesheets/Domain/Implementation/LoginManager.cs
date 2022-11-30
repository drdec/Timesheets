using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Timesheets.Domain.Interfaces;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models;
using Timesheets.Models.Auth;
using Timesheets.Models.Dto;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Timesheets.Domain.Implementation
{
    public class LoginManager : ILoginManager
    {
        private readonly JwtAccessOptions _jwtAccessOptions;

        public LoginManager(IOptions<JwtAccessOptions> jwtAccessOption)
        {
            _jwtAccessOptions = jwtAccessOption.Value;
        }

        public async Task<LoginResponse> Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
            };

            var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
            var securityHandler = new JwtSecurityTokenHandler();
            var accessToken = securityHandler.WriteToken(accessTokenRaw);

            var loginResponse = new LoginResponse()
            {
                AccessToken = accessToken,
                ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime()
            };

            return loginResponse;
        }
    }
}
