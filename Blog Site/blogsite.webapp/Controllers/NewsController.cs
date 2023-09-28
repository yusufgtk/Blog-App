using blogsite.business.Abstract;
using blogsite.entity;
using blogsite.webapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace blogsite.webapp.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewService _newService;
        public NewsController(INewService newService)
        {
            _newService=newService;
        }

        public IActionResult NewsList()
        {
            var news=_newService.GetNewsTop50();
            var newModels = new List<NewModel>(){};
            foreach(var New in news)
            {
                newModels.Add(new NewModel(){
                    Id=New.Id,
                    CategoryId=New.CategoryId,
                    Title=New.Title,
                    Content=New.Content,
                    ImageUrl=New.ImageUrl,
                    Source=New.Source,
                    Url=New.Url,
                    CreatedAt=New.CreatedAt
                });
            }
            return View(newModels);
        }
        [HttpPost]
        public IActionResult NewsList(string search)
        {
            var news = new List<New>(){};
            if(search==null)
            {
                news=_newService.GetNewsTop50();
            }
            else{
                news=_newService.GetNewsBySearch(search);
            }
            var newModels = new List<NewModel>(){};
            foreach(var New in news)
            {
                newModels.Add(new NewModel(){
                    Id=New.Id,
                    CategoryId=New.CategoryId,
                    Title=New.Title,
                    Content=New.Content,
                    ImageUrl=New.ImageUrl,
                    Source=New.Source,
                    Url=New.Url,
                    CreatedAt=New.CreatedAt
                });
            }
            return View(newModels);
        }
    }
}