using LDHBlog.IRepository;
using LDHBlog.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog.Repository
{
    public class WriterInfoRepository : BaseReposity<WriterInfo>, IWriterInfoRepository
    {
        public void Method()
        {
            Console.WriteLine("调用了Write的方法");
        }

    }
}
