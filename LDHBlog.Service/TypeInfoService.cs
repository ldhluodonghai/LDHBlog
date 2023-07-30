using LDHBlog.IRepository;
using LDHBlog.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LDHBlog.Service
{
    public class TypeInfoService :BaseService<Model.TypeInfo> ,ITypeInfoService
    {
        private readonly ITypeInfoRepository _itypeInfoRepository ;
        public TypeInfoService(ITypeInfoRepository itypeInfoRepository)
        {
            base._iBsaeRepository = itypeInfoRepository;
            _itypeInfoRepository = itypeInfoRepository;
        }
    }
}
