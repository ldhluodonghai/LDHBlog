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
    public class WriterService : BaseService<WriterInfo>,IWriterService
    {
        private readonly IWriterInfoRepository _iwriterInfoRepository;

        public WriterService(IWriterInfoRepository iwriterInfoRepository)
        {
            _iwriterInfoRepository = iwriterInfoRepository;
            base._iBsaeRepository = iwriterInfoRepository;
        }
    }
}
