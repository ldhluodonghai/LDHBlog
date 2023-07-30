using LDHBlog.Model;
using Org.BouncyCastle.Crypto;
using SqlSugar;
using System;

namespace LDHBlog.Model.DTO
{
    public class BlogNewsDto
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int BrowseCount { get; set; }
        public int LikeCount { get; set; }
        public int TypeId { get; set; }
        public int WritedId { get; set; }


        // public TypeInfo TypeInfo { get; set; }
        public string TypeName { get; set; }
        public string WriterName { get; set; }
       
       // public WriterInfo WriterInfo { get; set; }
    }
}
