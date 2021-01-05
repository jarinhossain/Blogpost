using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostManagement.Models.VMModel
{
    public class VMComment
    {
        public int Id { get; set; }
        public string Comment_Title { get; set; }
        public string UserName { get; set; }
        public DateTime Created_On { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
    }
}