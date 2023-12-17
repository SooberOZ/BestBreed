using BestBreed.Contracts;
using BestBreed.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BestBreed.UI.Controllers
{
    public class CatController : Controller
    {
        private readonly IRepository<Cat> _catRepository;

        public CatController(IRepository<Cat> catRepository)
        {
            _catRepository = catRepository;
        }

         public async Task<IActionResult> Index()
        {
            var cats = await _catRepository.GetAllAsync<Cat>();
            return View(cats);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var cat = _catRepository.GetById<Cat>(id);
            return cat != null ? View(cat) : NotFound();
        }
    }
}
