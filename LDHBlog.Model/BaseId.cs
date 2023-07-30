using System;
using SqlSugar;
namespace LDHBlog.Model
{
    public class BaseId
    {
        [SugarColumn(IsIdentity =true,IsPrimaryKey =true)]
        public int Id { get; set; }

    }
}
