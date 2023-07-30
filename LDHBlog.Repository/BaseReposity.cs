using LDHBlog.IRepository;
using LDHBlog.Model;
using SqlSugar;
using SqlSugar.IOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog.Repository
{
    public class BaseReposity<TEntity> : SimpleClient<TEntity>,IBsaeRepository<TEntity> where TEntity : class, new()
    {
        public BaseReposity(ISqlSugarClient context = null):base(context) {
            base.Context = DbScoped.Sugar;
            //创建数据库
            /*base.Context.DbMaintenance.CreateDatabase();
            base.Context.CodeFirst.InitTables(
                typeof(BlogNews),
                typeof(Model.TypeInfo),
                typeof(WriterInfo)
                );*/
        }
        public async Task<bool> CreateAsync(TEntity entity)
        {
           
            return await base.InsertAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await base.DeleteByIdAsync(id);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await base.UpdateAsync(entity);
        }

        //导航查询
        public virtual Task<TEntity> FindAsync(int id)
        {
            return base.GetByIdAsync(id);   
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await base.GetSingleAsync(func);
        }

        public virtual Task<List<TEntity>> QueryAsync()
        {
           return base.GetListAsync();
        }

        public virtual Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return base.GetListAsync(func);
        }

        public virtual Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<TEntity>().ToPageListAsync(page, size, total);
        }
        
        public virtual Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<TEntity>().Where(func).
                ToPageListAsync(page, size, total);
        }
    }
}
