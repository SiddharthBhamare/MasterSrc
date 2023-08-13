using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhotoBookRepository;
using PhotoBookWebService.PhotobookDbContext;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PhotoBookWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly PhotobookDBContext _dBContext;
        private readonly IConfiguration _configuration;
        public LoginController(ILogger<LoginController> logger, PhotobookDBContext dBContext, IConfiguration configuration)
        {
            _logger = logger;
            _dBContext = dBContext;
            _configuration = configuration;
        }

        [HttpGet(Name = "AuthenticateUser")]
        [AllowAnonymous]
        public async Task<WebHttpResponse> AuthenticateUser(string astrUserName, string astrPassword)
        {
            WebHttpResponse webHttpResponse = null;
            try
            {
                astrPassword = UtilityFunctions.encryptPassword(astrPassword);
                PhotobookUser UserInfo = await _dBContext.PhotobookUsers.FirstOrDefaultAsync(lobjuser => lobjuser.UserName.ToLower() == astrUserName.ToLower() && lobjuser.Password == astrPassword);

                if (UserInfo != null)
                {
                    string jwtToken = GenerateJSONWebToken(UserInfo);
                  webHttpResponse = UtilityFunctions.GetResponseObject(HttpStatusCode.OK, jwtToken,true);
                    //return webHttpResponse;
                }
                else
                {
                    webHttpResponse = UtilityFunctions.GetResponseObject(HttpStatusCode.Unauthorized, "",false);
                }
                return webHttpResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
        private string GenerateJSONWebToken(PhotobookUser userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
           {
                new Claim(ClaimTypes.NameIdentifier,userInfo.UserName),
                new Claim(ClaimTypes.Role,"admin")
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
              _configuration["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost (Name = "CreateUser")]
        [AllowAnonymous]
        public async Task<WebHttpResponse> CreateUser(PhotobookUser photobookUser)
        {
            WebHttpResponse webHttpResponse = null;
            try
            {
                string lstrPassword = UtilityFunctions.encryptPassword(photobookUser.Password);
                photobookUser.Password = lstrPassword;
                _dBContext.Add(photobookUser);
                _dBContext.SaveChangesAsync();
                webHttpResponse = UtilityFunctions.GetResponseObject(HttpStatusCode.OK, NoContent,true);
                return webHttpResponse;
            }
            catch (Exception ex)
            {
                webHttpResponse = UtilityFunctions.GetResponseObject(HttpStatusCode.InternalServerError, NoContent,false);
                throw ex;
            }
        }
        [HttpGet (Name = "IsUserAlreadyExist")]
        [AllowAnonymous]
        public async Task<bool> IsUserAlreadyExist(PhotobookUser user)
        {
            bool lblnPhoneEmailExist = await _dBContext.Persons.AnyAsync(lobjPerson => lobjPerson.Email.Equals(user.Person.Email) ||
             lobjPerson.Mobile.Equals(user.Person.Mobile));
            bool lblnValid = false;
            if (!lblnPhoneEmailExist)
            {
                lblnValid = await _dBContext.PhotobookUsers.AnyAsync(lobjUser => lobjUser.UserName.Equals(user.UserName)) ? false : true;
            }
            return lblnValid;
        }
    }
}
