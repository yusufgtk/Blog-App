using blogsite.business.Abstract;
using blogsite.entity;
using blogsite.webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogsite.webapp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        public AdminController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService=blogService;
            _categoryService=categoryService;
        }
        public IActionResult Blogs()
        {
            var blogs = _blogService.GetAll();
            var blogModels = new List<BlogModel>(){};
            foreach (var blog in blogs)
            {
                blogModels.Add(new BlogModel()
                {
                    Id=blog.Id,
                    Title=blog.Title,
                    Content=blog.Content,
                    ImageUrl=blog.ImageUrl,
                    CreatedAt=blog.CreatedAt,
                    NumberOfClicks=blog.NumberOfClicks,
                    CategoryId=blog.CategoryId
                });
            }
            return View(blogModels);
        }
        [HttpPost]
        public IActionResult Blogs(string search)
        {
            var blogs = new List<Blog>(){};
            
            if(search == null)
            {
                blogs = _blogService.GetAll();
            }
            else
            {
                blogs = _blogService.GetBlogsBySearch(search);
            }
            var blogModels = new List<BlogModel>(){};
            foreach (var blog in blogs)
            {
                blogModels.Add(new BlogModel()
                {
                    Id=blog.Id,
                    Title=blog.Title,
                    Content=blog.Content,
                    ImageUrl=blog.ImageUrl,
                    CreatedAt=blog.CreatedAt,
                    NumberOfClicks=blog.NumberOfClicks,
                    CategoryId=blog.CategoryId
                });
            }
            return View(blogModels);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        
        public IActionResult AddBlog()
        {
            ViewBag.Categories = _categoryService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult AddBlog(BlogModel blogModel, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    var errorMessage = error.ErrorMessage;
                    Console.WriteLine(errorMessage);
                    // Hata mesajını kullanarak sorunu çözmeye çalışın.
                }
                ViewBag.Categories = _categoryService.GetAll();
                return View(blogModel);
            }
            var blog = new Blog()
            {
                Title=blogModel.Title,
                Content=blogModel.Content,
                CategoryId=blogModel.CategoryId,
                CreatedAt=DateTime.Now,
            };
            if(file!=null&&file.Length!=0)
            {
                var imageUrl=Guid.NewGuid().ToString()+file.FileName;
                var path = Path.Combine("wwwroot","Images",imageUrl);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                blog.ImageUrl=imageUrl;
            }
            _blogService.Create(blog);
            TempData["Message"]="Blog başarıyla eklendi!";
            TempData["Alert"]="alert-success";
            return RedirectToAction("Blogs","Admin");
        }
        [HttpPost]
        public IActionResult DeleteBlog(int blogId)
        {
            if(blogId==null)
            {
                return NotFound();
            }
            var blog = _blogService.GetBlogById(blogId);
            if(blog==null)
            {
                return NotFound();
            }
            _blogService.Delete(blog);
            var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Images",blog.ImageUrl);
            System.IO.File.Delete(path);
            TempData["Message"]="Blog başarıyla silindi!";
            TempData["Alert"]="alert-success";
            return RedirectToAction("Blogs","Admin");
        }
        public IActionResult EditBlog(int blogId)
        {
            if(blogId==null)
            {
                return NotFound();
            }
            var blog = _blogService.GetBlogById(blogId);
            if(blog==null)
            {
                return NotFound();
            }
            BlogModel blogModel = new BlogModel(){
                Id=blog.Id,
                CategoryId=blog.CategoryId,
                Title=blog.Title,
                Content=blog.Content,
                ImageUrl=blog.ImageUrl,
            };
            ViewBag.Categories = _categoryService.GetAll();
            return View(blogModel);
        }
        [HttpPost]
        public IActionResult EditBlog(BlogModel blogModel, int Id, IFormFile file)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Categories = _categoryService.GetAll();
                return View(blogModel);
            }
            var blog = _blogService.GetBlogById(Id);
            if(blog==null)
            {
                return NotFound();
            }
            blog.CategoryId=blogModel.CategoryId;
            blog.Title=blogModel.Title;
            blog.Content=blogModel.Content;

            if(file!=null&&file.Length!=0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Images",blog.ImageUrl);
                System.IO.File.Delete(path);
                var imageUrl=Guid.NewGuid().ToString()+file.FileName;
                var path2 = Path.Combine("wwwroot","Images",imageUrl);
                using (var stream = new FileStream(path2, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                blog.ImageUrl=imageUrl;
            }
            _blogService.Update(blog);
            TempData["Message"]="Blog başarıyla güncellendi!";
            TempData["Alert"]="alert-success";
            return RedirectToAction("Blogs","Admin");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Categories
        public IActionResult Categories()
        {
            var categories = _categoryService.GetAll();
            var categoryModels = new List<CategoryModel>(){};
            foreach (var category in categories)
            {
                categoryModels.Add(new CategoryModel(){
                    Id=category.Id,
                    Name=category.Name
                });
            }
            return View(categoryModels);
        }
        [HttpPost]
        public IActionResult Categories(string search)
        {
            var categories=new List<Category>(){};
            if(search==null)
            {
                categories = _categoryService.GetAll();
            }
            else
            {
                categories = _categoryService.GetCategoriesBySearch(search);
            }

            var categoryModels = new List<CategoryModel>(){};
            foreach (var category in categories)
            {
                categoryModels.Add(new CategoryModel(){
                    Id=category.Id,
                    Name=category.Name
                });
            }
            return View(categoryModels);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryModel categoryModel)
        {
            if(!ModelState.IsValid)
            {
                return View(categoryModel);
            }
            var category = new Category()
            {
                Name=categoryModel.Name
            };
            _categoryService.Create(category);
            TempData["Message"]="Kategori başarıyla eklendi!";
            TempData["Alert"]="alert-success";
            return RedirectToAction("Categories","Admin");
        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            if(categoryId==null)
            {
                return NotFound();
            }
            var category = _categoryService.GetCategoryById(categoryId);
            if(category==null)
            {
                return NotFound();
            }
            _categoryService.Delete(category);
            TempData["Message"]="Kategori başarıyla silindi!";
            TempData["Alert"]="alert-success";
            return RedirectToAction("Categories","Admin");
        }
        public IActionResult EditCategory(int categoryId)
        {
            if(categoryId==null)
            {
                return NotFound();
            }
            var category = _categoryService.GetCategoryById(categoryId);
            if(category==null)
            {
                return NotFound();
            }
            CategoryModel categoryModel = new CategoryModel(){
                Id=category.Id,
                Name=category.Name
            };
            return View(categoryModel);
        }
        [HttpPost]
        public  IActionResult EditCategory(CategoryModel categoryModel, int Id)
        {
            if(!ModelState.IsValid)
            {
                return View(categoryModel);
            }
            if(Id==null)
            {
                return NotFound();
            }
            var category = _categoryService.GetCategoryById(Id);
            if(category==null)
            {
                return NotFound();
            }
            category.Name=categoryModel.Name;
            _categoryService.Update(category);
            TempData["Message"]="Kategori başarıyla güncellendi!";
            TempData["Alert"]="alert-success";
            return RedirectToAction("Categories","Admin");
        }

    }
}