using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogPostManagement.Models.VMModel
{
    public class VMBlogPost
    {
        public int Id { get; set; }
        public string BlogTitle { get; set; }
        public string UserName { get; set; }
        public DateTime Created_On { get; set; }
        public int CommentCount { get; set; }
        public List<VMComment> Comments { get; set; }
}
   
}