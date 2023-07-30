using LDHBlog.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog.IRepository
{
    public interface IWriterInfoRepository : IBsaeRepository<WriterInfo>
    {
        void Method();
    }
}
