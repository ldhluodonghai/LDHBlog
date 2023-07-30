
using LDHBlog.IService;
using LDHBlog_JWT.Utility.APIResult;

using LDHBlog_JWT.Utility.MD5_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog_JWT.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthoizeController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public AuthoizeController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpPost]
        public async Task<ApiResult> Login(string username,string pwd)
        {

            string v = MD5Helpher.MD5Encrypt32(pwd);
            //数据校验
            var writer = await _writerService.FindAsync(c => c.UserName == username && c.UserPwd == v);

            if (writer != null)
            {
              
                //登录成功
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, writer.Name),
                    new Claim("Id", writer.Id.ToString()),
                    new Claim("UserName", writer.UserName)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF-LDH"));
                var token = new JwtSecurityToken(
                    issuer: "http://localhost:6060",
                    audience: "http://localhost:5000",
                    claims: claims,
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                 );
                string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                return ApiResultHelper.Success(jwtToken);
            }
            else
            {
                return ApiResultHelper.Error("账号或密码错误");
            }
            
        }
       
    }
}
