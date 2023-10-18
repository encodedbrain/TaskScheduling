﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TaskScheduling.Models;

namespace TaskScheduling.Services;

public class TokenService
{
    
        public object GenerateToken(UserModel users)
        {
            var builder = WebApplication.CreateBuilder();

            string? hash = builder.Configuration.GetConnectionString("secret");

            if (hash != null)
            {
                var key = Encoding.ASCII.GetBytes(hash);

                if (users != null)
                {
                    SecurityTokenDescriptor config = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(
                            new[]
                            {
                                new Claim(ClaimTypes.Name, users.Nickname),
                                new Claim(
                                    ClaimTypes.Role,
                                    users.Password ?? throw new InvalidOperationException()
                                )
                            }
                        ),
                        Expires = DateTime.UtcNow.AddHours(2),
                        SigningCredentials = new SigningCredentials(
                            new SymmetricSecurityKey(key),
                            SecurityAlgorithms.HmacSha256Signature
                        ),
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenCreate = tokenHandler.CreateToken(config);
                    var token = tokenHandler.WriteToken(tokenCreate);

                    return new { token };
                }
            }

            return null!;
        }
    


}