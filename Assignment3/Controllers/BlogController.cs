using System;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Assignment3
{
    [Route("")]
    [Route("Blog")]
    public class BlogController : Controller
    {
        new IDataEntityRepository<BlogPost> _repo;

        public BlogController(IConfiguration configuration)
        {
            _repo = new BlogDBRepository(configuration);
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View(_repo.GetList());
        }

        [Route("Add")]
        public IActionResult Add()
        {
            return View(new BlogPostModel());
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost blog = BlogPostExtension.ToDataObject(model);
                _repo.Save(blog);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            BlogPost post = _repo.Get(id);
            BlogPostModel model = BlogPostExtension.ToModel(post);
            //Console.WriteLine(model.ID);
            return View(model);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost post = BlogPostExtension.ToDataObject(model);
                //Console.WriteLine(post.ID);
                _repo.Save(post);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}