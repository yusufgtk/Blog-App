using blogsite.business.Abstract;
using blogsite.entity;
using blogsite.webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogsite.webapp.Controllers
{
    public class BlogController:Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }
        public IActionResult BlogDetails(int blogId)
        {
            var blog = _blogService.GetBlogById(blogId);
            if (blog == null)
            {
                return NotFound();
            }
            blog.NumberOfClicks+=1;
            _blogService.Update(blog);
            var blogModel = new BlogModel(){
                Id = blog.Id,
                CategoryId=blog.CategoryId,
                Title = blog.Title,
                Content = blog.Content,
                ImageUrl=blog.ImageUrl,
                CreatedAt=blog.CreatedAt,
                NumberOfClicks = blog.NumberOfClicks
            };
            ViewBag.Categories=_categoryService.GetAll();
            return View(blogModel);
        }
        public IActionResult BlogList(int categoryId=-1)
        {
            var blogs = new List<Blog>(){};
            if (categoryId == -1)
            {
                blogs = _blogService.GetAll();
            }
            else
            {
                blogs = _blogService.GetBlogsByCategoryId(categoryId);
            }
            
            var blogModels = new List<BlogModel>(){};
            foreach(var blog in blogs)
            {
                blogModels.Add(new BlogModel(){
                    Id=blog.Id,
                    CategoryId=blog.CategoryId,
                    Title=blog.Title,
                    Content=blog.Content,
                    ImageUrl=blog.ImageUrl,
                    CreatedAt=blog.CreatedAt,
                    NumberOfClicks=blog.NumberOfClicks,
                });
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(blogModels);
        }
        [HttpPost]
        public IActionResult BlogList(string search)
        {
            var blogs = new List<Blog>(){};
            if(search==null)
            {
                blogs = _blogService.GetAll();
            }
            else
            {
                blogs = _blogService.GetBlogsBySearch(search);
            }
            var blogModels = new List<BlogModel>(){};
            foreach(var blog in blogs)
            {
                blogModels.Add(new BlogModel(){
                    Id=blog.Id,
                    CategoryId=blog.CategoryId,
                    Title=blog.Title,
                    Content=blog.Content,
                    ImageUrl=blog.ImageUrl,
                    CreatedAt=blog.CreatedAt,
                    NumberOfClicks=blog.NumberOfClicks
                });
            }
            ViewBag.Categories = _categoryService.GetAll();
            return View(blogModels);
        }
    }
}