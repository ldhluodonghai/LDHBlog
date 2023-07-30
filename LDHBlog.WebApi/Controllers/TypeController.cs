using LDHBlog.IRepository;
using LDHBlog.IService;
using LDHBlog.Model;
using LDHBlog.WebApi.Utility.APIResult;
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

    public class TypeController : ControllerBase
    {
        private readonly ITypeInfoService _typeInfoRepository;

        public TypeController(ITypeInfoService typeInfoRepository)
        {
            _typeInfoRepository = typeInfoRepository;
        }

        [HttpGet]
        public async Task<ApiResult> GetTypeInfo()
        {
            List<TypeInfo> typeInfos = await _typeInfoRepository.QueryAsync();

            if(typeInfos.Count == 0)
            {
                return ApiResultHelper.Error("没有查到");
            }
            return ApiResultHelper.Success(typeInfos);
        }

        [HttpPost]
        public async Task<ApiResult> Create(string name)
        {
            if (String.IsNullOrWhiteSpace(name)) return ApiResultHelper.Error("前端返回数据为空");
            TypeInfo typeInfos = new TypeInfo() {Name = name };
            bool state =await  _typeInfoRepository.CreateAsync(typeInfos);
            if(state)
            {
                return ApiResultHelper.Success(typeInfos);
            }
            return ApiResultHelper.Error("添加成功");
        }

        [HttpDelete]
        public async Task<ApiResult> Delete(int id)
        {
            bool task = await _typeInfoRepository.DeleteAsync(id);
            if (task)
            {
                return ApiResultHelper.Success(task);
            }
            return ApiResultHelper.Error("删除失败");
        }
        [HttpPut]
        public async Task<ApiResult> Edit(int id,string name)
        {
            var entity = await _typeInfoRepository.FindAsync(id);
    
            if (entity == null) return ApiResultHelper.Error("没查到该文章类型");

            entity.Name = name;
            
            bool state = await _typeInfoRepository.EditAsync(entity);
            if (state)
            {
                return ApiResultHelper.Success(entity);

            }
            return ApiResultHelper.Error("修改错误");
        }
        
    }

}
