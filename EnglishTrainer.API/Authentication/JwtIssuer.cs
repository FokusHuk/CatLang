﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EnglishTrainer.Core.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EnglishTrainer.API.Authentication
{
    public class JwtIssuer : IJwtIssuer
    {
        private readonly JwtConfiguration _configuration;

        public JwtIssuer(JwtConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                new Claim(JwtClaimTypes.Login, user.Login)
            };
            var secret = Encoding.ASCII.GetBytes(_configuration.Secret);
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.Add(_configuration.ExpiresAfter),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature));

            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return tokenString;
        }
    }
}
