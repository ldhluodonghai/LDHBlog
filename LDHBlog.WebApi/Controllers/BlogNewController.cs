using AutoMapper;
using LDHBlog.IService;
using LDHBlog.Model;
using LDHBlog.Model.DTO;
using LDHBlog.WebApi.Utility.APIResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace LDHBlog.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
 
    public class BlogNewController : ControllerBase
    {
        private readonly IBlogNewService _iBlogNewService;

        public BlogNewController(IBlogNewService iBlogNewService)
        {
            _iBlogNewService = iBlogNewService;
        }

        [HttpGet]
        public async  Task<ActionResult<ApiResult>> GetBlogNews()
        {
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            var  data=await  _iBlogNewService.QueryAsync(c =>c.WritedId==id);
            if (data.Count == 0)
            {
                return ApiResultHelper.Error("没有更多文章");
            }
            
            return ApiResultHelper.Success(data);
        }
        [HttpGet]
        public async  Task<ActionResult> GetNews()
        {
            var  data=await  _iBlogNewService.QueryAsync();
            if (data.Count == 0)
            {
                return NotFound("无");
            }
            
            return Ok(data);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResult>> Create(string title, string content, int typeId)
        {

            BlogNews blogNews = new BlogNews();
            blogNews.Title = title;
            blogNews.Content = content;
            blogNews.Time = DateTime.Now;
            blogNews.BrowseCount = 0;
            blogNews.LikeCount = 0;
            blogNews.TypeId = typeId;
            blogNews.WritedId = Convert.ToInt32(this.User.FindFirst("Id").Value);
            

            bool state = await _iBlogNewService.CreateAsync(blogNews);
            if (state)
            {

                return ApiResultHelper.Success(blogNews);
            }
            return ApiResultHelper.Error("发布失败");
        }
        [HttpDelete]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {

            bool state = await _iBlogNewService.DeleteAsync(id);
            if (state)
            {
                return ApiResultHelper.Success(state);
            }
            return ApiResultHelper.Error("删除失败");
        }

        [HttpPut]
        public async Task<ActionResult<ApiResult>> Edit(int id,string tile,string content,int typeId)
        {
            BlogNews news =await _iBlogNewService.FindAsync(id);
            if (news == null) return ApiResultHelper.Error("没有找到该文章");
            news.Title =tile; news.Content =content;news.TypeId = typeId;
            bool status =  await _iBlogNewService.EditAsync(news);
            if (status)
            {
                return ApiResultHelper.Success(status);
            }
            return ApiResultHelper.Error("编辑失败");
        }

        //分页
        [HttpGet]
        public async Task<ApiResult> GetBlogNewsPage([FromServices] IMapper mapper ,int page,int size)
        {
            RefAsync<int> total = 0;
            List<BlogNews> blogNewss =await _iBlogNewService.QueryAsync(page, size, total);
            try
            {
                List<BlogNewsDto> blogNewsDtos = mapper.Map<List<BlogNewsDto>>(blogNewss);
                return ApiResultHelper.Success(blogNewsDtos,total);
            }catch (Exception ex)
            {
                return ApiResultHelper.Error("映射错误");
            }
           

        }

    }
}
