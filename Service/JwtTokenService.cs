using Data;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Model;
using Repository;
using Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace Service
{

    
    public class JwtTokenService : IJwtTokenService
    {

        readonly IConfiguration _config;
        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }

        public JWTToken GenerateToken(CustomerModel customer)
        {
            var requiredClaims = new[]
           {
                new Claim(JwtRegisteredClaimNames.UniqueName, customer.Email),
                new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, customer.Name)
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretPassword"));
            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken access_token = new JwtSecurityToken(_config.GetSection("Issuer").Value,
                                                            _config.GetSection("Audience").Value,
                                                            requiredClaims,
                                                            expires: DateTime.Now.AddDays(1),
                                                            signingCredentials: credentials);

            JWTToken identity_token = new JWTToken()
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(access_token),
                expires_in = 86400,
                token_type = "bearer"
            };
            return identity_token;
        }

    }
}
