namespace Supermarket.API.Controllers
{
    using System.ComponentModel.DataAnnotations;
    using System.IdentityModel.Tokens.Jwt;
    using System.Net.Mime;
    using System.Text;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;
    using Supermarket.API.Extensions;
    using Supermarket.DataTransferModels.Authentication;
    using Supermarket.DataTransferModels.Categories;

    [ApiController]
    [Route(ApiRoutes.Authentication.BaseRoute)]
    [Produces("application/json")]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class AuthenticateController : ControllerBase
    {
        private IConfiguration _config;

        public AuthenticateController(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost(Name = nameof(Login))]
        [ProducesResponseType(typeof(LoginDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<IActionResult> Login([FromBody][Required] LoginDto data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = await AuthenticateUser(data);
            if (user == null)
            {
                return BadRequest();

            }

            var tokenString = GenerateJSONWebToken(user);
            return Ok(new { Token = tokenString, Message = "Success" });
        }

        private async Task<LoginDto> AuthenticateUser(LoginDto login)
        {
            LoginDto user = null;

            //Validate the User Credentials      
            //Demo Purpose, I have Passed HardCoded User Information      
            if (login.UserName == "test")
            {
                user = new LoginDto { UserName = "test", Password = "123" };
            }
            return user;
        }

        private string GenerateJSONWebToken(LoginDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

