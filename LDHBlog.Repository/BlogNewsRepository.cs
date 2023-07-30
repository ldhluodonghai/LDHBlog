using LDHBlog.IRepository;
using LDHBlog.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog.Repository
{
    public class BlogNewsRepository : BaseReposity<BlogNews>, IBlogNewRepository
    {
        public async override Task<List<BlogNews>> QueryAsync()
        {
           return await base.Context.Queryable<BlogNews>()
                .Mapper(c=> c.TypeInfo,c=> c.TypeId,c=>c.TypeInfo.Id)
                .Mapper(c=>c.WriterInfo,c=>c.WritedId,c=>c.WriterInfo.Id)
                .ToListAsync();
        }

        public async override Task<List<BlogNews>> QueryAsync(Expression<Func<BlogNews, bool>> func)
        {
            return await base.Context.Queryable<BlogNews>()
                .Where(func)
               .Mapper(c => c.TypeInfo, c => c.TypeId, c => c.TypeInfo.Id)
               .Mapper(c => c.WriterInfo, c => c.WritedId, c => c.WriterInfo.Id)
               .ToListAsync();
        }

        public override Task<List<BlogNews>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<BlogNews>()
                .ToPageListAsync(page, size, total);
        }
       /* public List<TEntity> ToPageList(int pageIndex, int pageSize, ref int totalCount)
        {
            // 计算要跳过的记录数
            int skipCount = (pageIndex - 1) * pageSize;

            // 获取总记录数
            totalCount = _orm.Queryable<TEntity>().Count();

            // 分页查询
            List<TEntity> list = _orm.Queryable<TEntity>()
                                    .Skip(skipCount)
                                    .Take(pageSize)
                                    .ToList();

            // 返回分页结果
            return list;
        }*/

        public override Task<List<BlogNews>> QueryAsync(Expression<Func<BlogNews, bool>> func, int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<BlogNews>()
                .Where (func)
                .Mapper(c=>c.WriterInfo,c=>c.WritedId,c=>c.WriterInfo.Id)
                .Mapper(c=>c.TypeInfo,c=>c.TypeId,c=>c.TypeInfo.Id)
                .ToPageListAsync (page, size, total);

        }
    }
}
