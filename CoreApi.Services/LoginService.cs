using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CoreAPI.Dto;
using CoreApi.Services.Infrastructure;
using CoreApi.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using CoreApi.Helper;
using Microsoft.Extensions.Options;

namespace CoreApi.Services
{
    public class LoginService : ILoginService
    {
        private DataManager _dataManager;
        public LoginService(IConfiguration configuration, IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
            _dataManager = new DataManager(configuration);
        }

        private readonly AppSettings _appSettings;
        private TResponse _response = new TResponse();
        private DataTable _dataTable = new DataTable();

        public TResponse Login(LoginDto loginDto)
        {
            _dataTable = _dataManager.GetDataTable("SELECT Usr_kid,  Usr_Passkey, Usr_Password FROM H_Usr where Usr_Status=1 and Usr_Code='" + loginDto.UserCode + "'");
            if (_dataTable != null && _dataTable.Rows.Count > 0)
            {
                var passkey = _dataTable.Rows[0]["Usr_Passkey"].ToString();
                var password = _dataTable.Rows[0]["Usr_Password"].ToString();
                if (string.Equals(password, Cryptography.Encrypt(loginDto.Password, passkey)))
                {
                    var kid = _dataTable.Rows[0]["Usr_kid"].ToString();
                    _dataTable = _dataManager.GetDataTable("SELECT Usr_kid, Usr_FirstName, Usr_MiddleName, Usr_LastName, Usr_Code, Usr_mobNo, Usr_Email FROM H_Usr where Usr_Status=1 and Usr_kid=" + kid);
                    var userDto = new UserDto()
                    {
                        Id = Convert.ToInt32(kid),
                        Usercode = _dataTable.Rows[0]["Usr_Code"].ToString(),
                        UsrFirstName = _dataTable.Rows[0]["Usr_FirstName"].ToString(),
                        UsrMiddleName = _dataTable.Rows[0]["Usr_MiddleName"].ToString(),
                        UsrLastName = _dataTable.Rows[0]["Usr_LastName"].ToString(),
                        UsrMobNo = _dataTable.Rows[0]["Usr_mobNo"].ToString(),
                        UsrEmail = _dataTable.Rows[0]["Usr_Email"].ToString(),
                        Token = GenerateToken(kid)
                    };

                    _response.ResponseCode = (int)HttpStatusCode.OK;
                    _response.ResponseStatus = true;
                    _response.ResponseMessage = "Login Success.";
                    _response.ResponseData = userDto;
                }
                else
                {
                    _response.ResponseCode = (int)HttpStatusCode.Unauthorized;
                    _response.ResponseStatus = false;
                    _response.ResponseMessage = "Incorrect Password.";
                }
            }
            else
            {
                _response.ResponseCode = (int)HttpStatusCode.NotFound;
                _response.ResponseStatus = false;
                _response.ResponseMessage = "User not found.";
            }
            return _response;
        }

        public string GenerateToken(string id)
        {
            var encString = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var x = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id) }),
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(encString),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandlerx = new JwtSecurityTokenHandler();
            return tokenHandlerx.WriteToken(tokenHandlerx.CreateToken(x));

        }
    }
}
