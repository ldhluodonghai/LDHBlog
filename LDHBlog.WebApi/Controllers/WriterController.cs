using AutoMapper;
using LDHBlog.IRepository;
using LDHBlog.IService;
using LDHBlog.Model;
using LDHBlog.Model.DTO;
using LDHBlog.WebApi.Utility.APIResult;
using LDHBlog.WebApi.Utility.MD5_;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LDHBlog.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public async Task<ApiResult> GetWriter()
        {
           List<WriterInfo> writerInfos = await  _writerService.QueryAsync();
           if (writerInfos.Count == 0) return ApiResultHelper.Error("没有查到");
           return ApiResultHelper.Success(writerInfos);
        }
        [HttpGet]
        public async Task<ApiResult> FindtWriter([FromServices]IMapper mapper,int id)
        {
            var writer= await _writerService.FindAsync(id);

            WriterInfoDto writerInfoDto = mapper.Map<WriterInfoDto>(writer);
           if (writerInfoDto == null) return ApiResultHelper.Error("没有查到");
           return ApiResultHelper.Success(writerInfoDto);
        }
        [HttpPost]
        public async Task<ApiResult> Create(string name,string pwd,string userName)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(pwd) || string.IsNullOrWhiteSpace(userName))
                return ApiResultHelper.Error("有空值，数据不对");
            WriterInfo writerInfo = new WriterInfo()
            {
                UserName = userName,
                UserPwd = MD5Helpher.MD5Encrypt32(pwd),
                Name = name
            };
            WriterInfo task =await _writerService.FindAsync(c => c.UserName == userName);
            if (task != null) return ApiResultHelper.Error("用户名已经存在，添加失败");
            bool v = await _writerService.CreateAsync(writerInfo);

            return ApiResultHelper.Success(v);
        }

        [HttpPut]
        public async Task<ApiResult> Edit(string name)
        {
            int id = Convert.ToInt32(this.User.FindFirst("id").Value);
            WriterInfo writer = await _writerService.FindAsync(id);
            writer.Name = name;
            bool b =await _writerService.EditAsync(writer);
            if (b)
            {
                return ApiResultHelper.Success("修改成功");
            }
            return ApiResultHelper.Error("修改失败");
        }
    }
}
