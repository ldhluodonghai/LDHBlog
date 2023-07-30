using LDHBlog.IRepository;
using LDHBlog.IService;
using LDHBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog.Service
{
    public class BlogNewService : BaseService<BlogNews>, IBlogNewService
    {
        private readonly IBlogNewRepository _iBlogNewRepository;
        public BlogNewService(IBlogNewRepository iBlogNewRepository)
        {
            base._iBsaeRepository = iBlogNewRepository;
            _iBlogNewRepository = iBlogNewRepository;
        }
    }
}