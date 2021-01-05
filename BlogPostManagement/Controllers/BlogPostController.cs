using BlogPostManagement.Models;
using BlogPostManagement.Models.VMModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogPostManagement.Controllers
{
    public class BlogPostController : ApiController
    {
        private BlogPostDBContext db = new BlogPostDBContext();
        public BlogPostController()
        {
            db.Configuration.LazyLoadingEnabled = false;
            db.Configuration.ProxyCreationEnabled = false;
        }
        public List<Blog> GetAll()
        {
            List<Blog> blogobj = (from blog in db.Blogs
                                     select blog).Include("User").Include("Comments").ToList(); 
            return blogobj;
        }

        [HttpGet]
        public IHttpActionResult All()
        {

            List<VMBlogPost> list = (from blog in db.Blogs
                                     select new VMBlogPost
                                     {
                                         Id = blog.Id,
                                         BlogTitle = blog.Blog_Title,
                                         UserName = blog.User.User_Name,
                                         Created_On = (DateTime)blog.Created_On,
                                         CommentCount = blog.Comments.Count,
                                         Comments = blog.Comments.Select(y =>
                                        new VMComment
                                        {
                                            Id = y.Id,
                                            Comment_Title = y.Comment_Title,
                                            UserName = y.User.User_Name,
                                            Created_On = (DateTime)y.Created_On,
                                            LikeCount = y.Comment_Reaction.Where(like => like.Is_Like == true).Count(),
                                            DislikeCount = y.Comment_Reaction.Where(like => like.Is_Like == false).Count(),
                                        }).ToList(),
                                     }).ToList();

            return Ok(list);
        }
    }
}
