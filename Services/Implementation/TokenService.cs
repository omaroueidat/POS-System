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

        public string CreateJwtToken(SuperMarket superMarket)
        {
            // Create Claims
            var claims = new List<Claim>();  // create a list of claims

            claims.Add(new Claim(ClaimTypes.Email, superMarket.Email)); // add the email to the claim

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); // create a secuirity key from the jwt key we made
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); 

            

            var token = new JwtSecurityToken(  // creating the token
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30), // expires after 30 minutes
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token); // returns the token as a string
        }

        public string CreateJwtTokenForEmployee(Employee employee)
        {
            // Create Claims
            var claims = new List<Claim>();  // create a list of claims

            claims.Add(new Claim("Passcode" , employee.EmployeePasscode.Passcode.ToString())); // add the passcode to the claim
 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])); // create a secuirity key from the jwt key we made
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(  // creating the token
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(12), // expires after 12 hours
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token); // returns the token as a string
        }
    }
}
