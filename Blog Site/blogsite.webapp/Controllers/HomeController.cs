using blogsite.business.Abstract;
using blogsite.webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogsite.webapp.Controllers;

public class HomeController : Controller
{
    private readonly IBlogService _blogService;
    private readonly ICategoryService _categoryService;

    public HomeController(IBlogService blogService, ICategoryService categoryService)
    {
        _blogService=blogService;
        _categoryService=categoryService;
    }
    public IActionResult Index()
    {
        var blogsTop10=_blogService.GetBlogsTop10();
        var blogModels=new List<BlogModel>(){};
        foreach(var blog in blogsTop10)
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
        ViewBag.Categories=_categoryService.GetAll();
        return View(blogModels);
    }

    public IActionResult AboutUs()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }

}
