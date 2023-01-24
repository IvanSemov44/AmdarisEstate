namespace IvanRealEstate.Application.Handlers.UsersHandlers
{
    using MediatR;

    using System.Text;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Extensions.Configuration;

    using IvanRealEstate.Entities.Models;
    using IvanRealEstate.Application.Commands.UsersCommands;

    public sealed class ValidateUserHandler : IRequestHandler<ValidateUserCommand, bool>
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;

        private User? _user;

        public ValidateUserHandler(UserManager<User> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }

        public async Task<bool> Handle(ValidateUserCommand request, CancellationToken cancellationToken)
        {
            _user = await _userManager.FindByNameAsync(request.UserForAuthentication.UserName);

            var result = (_user != null &&
                await _userManager.CheckPasswordAsync(_user, request.UserForAuthentication.Password));

            //result = await _userManager.GetUsersInRoleAsync();
            return result;
        }

        //public async Task<string> CreateToken()
        //{
        //    var signingCredentials = GetSigningCredentials();
        //    var claims = await GetClaims();
        //    var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

        //    return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        //}

        //private SigningCredentials GetSigningCredentials()
        //{
        //    var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
        //    var secret = new SymmetricSecurityKey(key);

        //    return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        //}

        //private async Task<List<Claim>> GetClaims()
        //{
        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, _user.UserName)
        //    };

        //    var roles = await _userManager.GetRolesAsync(_user);
        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }

        //    return claims;
        //}

        //private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        //{
        //    var jwtSettings = _config.GetSection("JWTSetting");

        //    var tokenOptions = new JwtSecurityToken(
        //        issuer: jwtSettings["validIssuer"],
        //        audience: jwtSettings["validAudience"],
        //        claims: claims,
        //        expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
        //        signingCredentials: signingCredentials);

        //    return tokenOptions;
        //}
    }
}
