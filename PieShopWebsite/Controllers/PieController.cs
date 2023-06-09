using Microsoft.AspNetCore.Mvc;
using PieShopWebsite.Models;
using PieShopWebsite.ViewModels;

namespace PieShopWebsite.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        //constructor injection
        //an instance of the repository implementing the IPieRepository interface and an instance of the repository implementing
        //the ICategoryRepository interface will be provided when creating an instance of the PieController
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese Cakes";
            // pass the collection of pies from model to the view
            //return View(_pieRepository.AllPies);
            PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese Cakes");
            return View(pieListViewModel);
        }
    }
}
