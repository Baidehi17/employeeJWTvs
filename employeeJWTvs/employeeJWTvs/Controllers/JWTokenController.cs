using employeeJWTvs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace employeeJWTvs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JWTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly EmployeeJwtContext _context;

        public JWTokenController(IConfiguration configuration, EmployeeJwtContext context)
        { 
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post (EmployeedetailJwt employeedetail)
        {
            if(employeedetail!=null && employeedetail.Email!=null && employeedetail.Password!=null)
            {
                var userLoginDetail = await Getuser(employeedetail.Email,employeedetail.Password);

                if (userLoginDetail!=null) 
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("SkypeId" , userLoginDetail.SkypeId.ToString()),
                        new Claim("Email" , userLoginDetail.Email),
                        new Claim("FirstName" , userLoginDetail.FristName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials : signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }   
        }

        public async Task<EmployeedetailJwt> Getuser(string email, string password)
        {
            return await _context.EmployeedetailJwts.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
