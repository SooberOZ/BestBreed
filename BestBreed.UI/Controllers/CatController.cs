using BestBreed.Contracts;
using BestBreed.DataLayer;
using BestBreed.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BestBreed.UI.Controllers
{
    public class CatController : Controller
    {
        private readonly IRepository<Cat> _catRepository;
        private readonly IUnitOfWork<BestBreedContext> _unitOfWork;

        public CatController(IRepository<Cat> catRepository, IUnitOfWork<BestBreedContext> unitOfWork)
        {
            _catRepository = catRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var cats = await _catRepository.GetAllAsync();
            return View(cats);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var cat = await _catRepository.GetByIdAsync(id);
            return cat != null ? View(cat) : NotFound();
        }

        public async Task<IActionResult> SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
