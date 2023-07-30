using LDHBlog.IRepository;
using LDHBlog.IService;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        //从子类的构造函数中传入
        protected IBsaeRepository<TEntity> _iBsaeRepository;

        

        public Task<bool> CreateAsync(TEntity entity)
        {
            return _iBsaeRepository.CreateAsync(entity);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _iBsaeRepository.DeleteAsync(id);
        }

        public Task<bool> EditAsync(TEntity entity)
        {
            return _iBsaeRepository.EditAsync(entity);
        }

        //public virtual Task<TEntity> FindAsync(TEntity id)
        public  Task<TEntity> FindAsync(int id)
        {
            //虚方法 =。用户数据，不能将密码也发给前端 把dto导航查询
            return _iBsaeRepository.FindAsync(id);  
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return _iBsaeRepository.FindAsync(func);
        }

        public  Task<List<TEntity>> QueryAsync()
        {
            return _iBsaeRepository.QueryAsync();
        }

        public  Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return _iBsaeRepository.QueryAsync(func);
        }

        public  Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return _iBsaeRepository.QueryAsync(page, size, total);
        }

        public  Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return _iBsaeRepository.QueryAsync(func,page,size,total);
        }
    }
}
