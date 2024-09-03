using Entities.Domain.Application;
using Entities.Models.EmployeeModels;
using Entities.Models.SuperMarketModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateJwtTokenForEmployee(AppUser user, Employee employee, string role)
        {
            // Check for the role
            if (role != "Employee")
            {
                return null;
            }


            // Create Claims
            var claims = new List<Claim> // create a list of claims
            {
                new Claim(ClaimTypes.Email, user.Email), // add the email to the claim

                new Claim(ClaimTypes.NameIdentifier, employee.EmployeeId.ToString()), // Add Id of the Employee

                new Claim(ClaimTypes.Role, role)
            };  

            return CreateJwtToken(claims, DateTime.Now.AddHours(8));
        }

        public string CreateJwtTokenForSuperMarket(AppUser user, SuperMarket superMarket, string role)
        {
            // Check the role
            if (role != "SuperMarket")
            {
                return null;
            }

            // Create Claims
            var claims = new List<Claim>();  // create a list of claims

            claims.Add(new Claim(ClaimTypes.Email, user.Email)); // add the email to the claim

            claims.Add(new Claim(ClaimTypes.NameIdentifier, superMarket.SuperMarketId.ToString())); // Add Id of the Employee

            claims.Add(new Claim(ClaimTypes.Role, role));

            return CreateJwtToken(claims, DateTime.Now.AddMinutes(60));
        }

        public string CreateJwtTokenForAdmin(AppUser user, Admin admin, string role)
        {
            // Check the role
            if (role != "Admin")
            {
                return null;
            }

            // Create Claims
            var claims = new List<Claim> // create a list of claims
            {
                new Claim(ClaimTypes.Email, user.Email), // add the email to the claim

                new Claim(ClaimTypes.NameIdentifier, admin.AdminId.ToString()), // Add Id of the Employee

                new Claim(ClaimTypes.Role, role)
            };  

            return CreateJwtToken(claims, DateTime.Now.AddMinutes(60));
        }

        private string CreateJwtToken(List<Claim> claims, DateTime expires)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); // create a secuirity key from the jwt key we made
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(  // creating the token
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expires, // expiry date
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token); // returns the token as a string
        }

    }
}
