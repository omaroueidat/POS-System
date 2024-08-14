using Microsoft.AspNetCore.Mvc;

namespace POS_System.Dummy_Data
{
    public class c__codes_to_use
    {
        // To Call a stored procedure
        /*public async Task<List<MyModel>> CallMyStoredProcedureAsync(int parameter1)
        {
            var parameter = new SqlParameter("@Parameter1", parameter1);
            return await MyModels.FromSqlRaw("EXEC MyStoredProcedure @Parameter1", parameter).ToListAsync();
        }*/

        // To Hash A Password
        // Install the package AspNetCore.Identity
        // We have to make a new PasswordHasher<string>() in the constructor of the controller

        /*[HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var hashedPassword = _userService.HashPassword(model.Password);
            // Save hashedPassword to the database with the user information

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Retrieve the stored hashed password for the user
            string storedHashedPassword = GetStoredHashedPasswordForUser(model.Username);

            if (_userService.VerifyPassword(storedHashedPassword, model.Password))
            {
                return Ok("Login successful");
            }

            return Unauthorized("Invalid credentials");
        }*/
    }
}
